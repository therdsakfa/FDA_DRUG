Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient

Namespace DataCenter
    Public Class PersonData
        Inherits WS_Center_Data

        Private Sub GetDataFor_MainPerson()
            GET_ADDR_CONTACT("")
        End Sub
        Public Sub Bind_MainPerson2(ByRef cls_MainPerson As MainPerson, ByRef lcnsid As String, ByVal lcnno As String)
            'GetDataFor_MainPerson()
            'WS_CENTER_systhmbl = WS_CENTER.Get_Thmblcd(Integer.Parse(WS_CENTER_SYSADDR_CONTACT.provincecd), Integer.Parse(WS_CENTER_SYSADDR_CONTACT.districtcd), Integer.Parse(WS_CENTER_SYSADDR_CONTACT.thumbolcd))
            'WS_CENTER_sysamphr = WS_CENTER.Get_Amphrcd(Integer.Parse(WS_CENTER_SYSADDR_CONTACT.provincecd), Integer.Parse(WS_CENTER_SYSADDR_CONTACT.districtcd))
            'WS_CENTER_syschngwt = WS_CENTER.Get_Chngwtcd(Integer.Parse(WS_CENTER_SYSADDR_CONTACT.provincecd))

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            Dim dao_customer_addr As New DAO_CPN.clsDBsyslctaddr
            Dim dao_falcn As New DAO.clsDBfalcn
            Dim dao_ID As New DAO_CPN.clsDBsyslcnsid
            dao_falcn.GetDataby_lcnsid_lcnno(lcnsid, lcnno)
            dao_customer.GetDataby_lcnsid(lcnsid)
            dao_ID.GetDataby_lcnsid(lcnsid)
            dao_customer_addr.GetDataby_lcnsid_lctcd(lcnsid, dao_falcn.fields.lctcd)

            cls_MainPerson.name = dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
            cls_MainPerson.citiz_no = dao_ID.fields.taxno
            cls_MainPerson.room = dao_customer_addr.fields.room
            cls_MainPerson.floor = dao_customer_addr.fields.floor
            cls_MainPerson.building = dao_customer_addr.fields.building
            cls_MainPerson.number_addr = dao_customer_addr.fields.thaaddr
            cls_MainPerson.moo = dao_customer_addr.fields.mu
            cls_MainPerson.soi = dao_customer_addr.fields.thasoi
            cls_MainPerson.road = dao_customer_addr.fields.tharoad

            cls_MainPerson.thmbolcd = dao_customer_addr.fields.thmblcd
            cls_MainPerson.districtcd = dao_customer_addr.fields.amphrcd
            cls_MainPerson.provincecd = dao_customer_addr.fields.chngwtcd

            cls_MainPerson.zipcode = dao_customer_addr.fields.zipcode
            cls_MainPerson.tel_home = dao_customer_addr.fields.tel
            cls_MainPerson.tel_telephone = dao_customer_addr.fields.fax
            'cls_MainPerson.email = dao_customer_addr.fields.email
            'cls_MainPerson.nation = dao_customer_addr.fields.na
        End Sub
        Public Sub Bind_MainPerson(ByRef cls_MainPerson As MainPerson)
            'GetDataFor_MainPerson()
            'WS_CENTER_systhmbl = WS_CENTER.Get_Thmblcd(Integer.Parse(WS_CENTER_SYSADDR_CONTACT.provincecd), Integer.Parse(WS_CENTER_SYSADDR_CONTACT.districtcd), Integer.Parse(WS_CENTER_SYSADDR_CONTACT.thumbolcd))
            'WS_CENTER_sysamphr = WS_CENTER.Get_Amphrcd(Integer.Parse(WS_CENTER_SYSADDR_CONTACT.provincecd), Integer.Parse(WS_CENTER_SYSADDR_CONTACT.districtcd))
            'WS_CENTER_syschngwt = WS_CENTER.Get_Chngwtcd(Integer.Parse(WS_CENTER_SYSADDR_CONTACT.provincecd))


            cls_MainPerson.name = WS_CENTER_SYSADDR_CONTACT.name
            cls_MainPerson.citiz_no = WS_CENTER_SYSADDR_CONTACT.citiz_no
            cls_MainPerson.room = WS_CENTER_SYSADDR_CONTACT.room
            cls_MainPerson.floor = WS_CENTER_SYSADDR_CONTACT.floor
            cls_MainPerson.building = WS_CENTER_SYSADDR_CONTACT.building
            cls_MainPerson.number_addr = WS_CENTER_SYSADDR_CONTACT.number_addr
            cls_MainPerson.moo = WS_CENTER_SYSADDR_CONTACT.moo
            cls_MainPerson.soi = WS_CENTER_SYSADDR_CONTACT.soi
            cls_MainPerson.road = WS_CENTER_SYSADDR_CONTACT.road

            cls_MainPerson.thmbolcd = WS_CENTER_systhmbl.thathmblnm
            cls_MainPerson.districtcd = WS_CENTER_sysamphr.thaamphrnm
            cls_MainPerson.provincecd = WS_CENTER_syschngwt.thachngwtnm

            cls_MainPerson.zipcode = WS_CENTER_SYSADDR_CONTACT.zipcode
            cls_MainPerson.tel_home = WS_CENTER_SYSADDR_CONTACT.tel_home
            cls_MainPerson.tel_telephone = WS_CENTER_SYSADDR_CONTACT.tel_telephone
            cls_MainPerson.email = WS_CENTER_SYSADDR_CONTACT.email
            cls_MainPerson.nation = WS_CENTER_SYSADDR_CONTACT.nation
        End Sub


        Public Sub Bind_MainCompany(ByRef cls_MainCompany As MainCompany)
            cls_MainCompany.name = dao_syslcnsnm.fields.thanm + "  " + dao_syslcnsnm.fields.thalnm
            cls_MainCompany.citiz_no = dao_syslcnsid.fields.ctzno
            cls_MainCompany.room = dao_syslctaddr.fields.room
            cls_MainCompany.floor = dao_syslctaddr.fields.floor
            cls_MainCompany.building = dao_syslctaddr.fields.building
            cls_MainCompany.number_addr = dao_syslctaddr.fields.thaaddr
            cls_MainCompany.moo = dao_syslctaddr.fields.mu
            cls_MainCompany.soi = dao_syslctaddr.fields.thasoi
            cls_MainCompany.road = dao_syslctaddr.fields.tharoad
            cls_MainCompany.thmbolcd = WS_CENTER_systhmbl.thathmblnm
            cls_MainCompany.districtcd = WS_CENTER_sysamphr.thaamphrnm
            cls_MainCompany.provincecd = WS_CENTER_syschngwt.thachngwtnm
            cls_MainCompany.zipcode = dao_syslctaddr.fields.zipcode
            cls_MainCompany.tel_home = dao_syslctaddr.fields.tel
            cls_MainCompany.tel_telephone = ""
            cls_MainCompany.email = ""
            cls_MainCompany.nation = ""

        End Sub



    
    End Class
    Public Class WS_Center_Data
        Inherits DAO_CENTER_DATA
        Public WS_CENTER As New WS_CENTER.WS_CENTER
        Public WS_CENTER_SYSADDR_CONTACT As New WS_CENTER.CLC_SYSADDR_CONTACT

        Public Sub GET_ADDR_CONTACT(ByVal _CITIEZEN_ID As String)
            Dim ws As New WS_CENTER.WS_CENTER

            WS_CENTER_SYSADDR_CONTACT = ws.GET_ADDR_CONTACT(_CITIEZEN_ID)  'test"3709800064166"
        End Sub

        Public Sub Get_DATA_BASIC_ADDR(ByVal _lcnsid_customer As Integer, ByVal _lcnno As String)
            Bind_DAO(_lcnsid_customer, _lcnno)
            Dim ws As New WS_CENTER.WS_CENTER
            WS_CENTER_systhmbl = ws.Get_Thmblcd(Integer.Parse(dao_syslctaddr.fields.chngwtcd), Integer.Parse(dao_syslctaddr.fields.amphrcd), Integer.Parse(dao_syslctaddr.fields.thmblcd))
            WS_CENTER_sysamphr = ws.Get_Amphrcd(Integer.Parse(dao_syslctaddr.fields.chngwtcd), Integer.Parse(dao_syslctaddr.fields.amphrcd))
            WS_CENTER_syschngwt = ws.Get_Chngwtcd(Integer.Parse(dao_syslctaddr.fields.chngwtcd))
        End Sub
        'จ อ ต ยังไม่เสร็จ
        Public Sub Get_DATA_ADDR_SYSCHNGWT(ByVal chngwtcd As Integer)
            WS_CENTER_syschngwt = WS_CENTER.Get_Chngwtcd(Integer.Parse(dao_syslctaddr.fields.chngwtcd))
        End Sub
        Public Sub Get_DATA_ADDR_SYSAMPHR(ByVal chngwtcd As Integer, ByVal amphrcd As Integer)
            WS_CENTER_sysamphr = WS_CENTER.Get_Amphrcd(Integer.Parse(dao_syslctaddr.fields.chngwtcd), Integer.Parse(dao_syslctaddr.fields.amphrcd))
        End Sub
        Public Sub Get_DATA_ADDR_SYSTHMBL(ByVal chngwtcd As Integer, ByVal amphrcd As Integer, ByVal thmblcd As Integer)
            WS_CENTER_systhmbl = WS_CENTER.Get_Thmblcd(Integer.Parse(dao_syslctaddr.fields.chngwtcd), Integer.Parse(dao_syslctaddr.fields.amphrcd), Integer.Parse(dao_syslctaddr.fields.thmblcd))
        End Sub
        Public WS_CENTER_systhmbl As New WS_CENTER.CLC_THMBLCD
        Public WS_CENTER_sysamphr As New WS_CENTER.CLC_AMPHRCD
        Public WS_CENTER_syschngwt As New WS_CENTER.CLC_CHAWTCD

    End Class

    Public Class DAO_CENTER_DATA
        Public dao_dalcn As New DAO_DRUG.ClsDBdalcn
        Public dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        Public dao_syslcnsnm As New DAO_CPN.clsDBsyslcnsnm
        Public dao_syslctnm As New DAO_CPN.clsDBsyslctnm
        Public dao_syslctaddr As New DAO_CPN.clsDBsyslctaddr

        Public Sub Bind_DAO(ByVal _lcnsid_customer As Integer, ByVal _lcnno As String)
            dao_dalcn.GetDataby_lcnsid_lcnno(Integer.Parse(_lcnsid_customer), _lcnno)
            dao_syslcnsid.GetDataby_lcnsid(Integer.Parse(_lcnsid_customer))
            dao_syslcnsnm.GetDataby_lcnsid(Integer.Parse(_lcnsid_customer))
            dao_syslctaddr.GetDataby_lcnsid_lctcd(Integer.Parse(_lcnsid_customer), dao_falcn.fields.lctcd)
        End Sub


    End Class


    Public Class DATA_MASTER
        Public WS_CENTER As New WS_CENTER.WS_CENTER
        'Public WS_LGTFOOD As New WS_LGTFOOD.WS_LGTFOOD

        Sub syschngwt(ByRef main_class As MAIN_MASTER)
            Dim cls As New WS_CENTER.syschngwt
            For Each sub_cls In WS_CENTER.GetData_Changwat()
                main_class.syschngwt.Add(sub_cls)
                cls = New WS_CENTER.syschngwt
            Next
        End Sub
        Sub sysamphr(ByRef main_class As MAIN_MASTER)
            Dim cls As New WS_CENTER.sysamphr
            For Each sub_cls In WS_CENTER.GetData_Amphur()
                main_class.sysamphr.Add(sub_cls)
                cls = New WS_CENTER.sysamphr
            Next
        End Sub
        Sub systhmbl(ByRef main_class As MAIN_MASTER)
            Dim cls As New WS_CENTER.systhmbl
            For Each sub_cls In WS_CENTER.GetData_Thumbol()
                main_class.systhmbl.Add(sub_cls)
                cls = New WS_CENTER.systhmbl
            Next
        End Sub

#Region "สบ5"
        Sub fafdtype(ByRef main_class As MAIN_MASTER)
            Dim cls As New WS_LGTFOOD.fafdtype
            For Each sub_cls In WS_LGTFOOD.fafdtype()
                main_class.ws_fafdtype.Add(sub_cls)
                cls = New WS_LGTFOOD.fafdtype
            Next
        End Sub
        'Sub fafmtcd(ByRef main_class As MAIN_MASTER)
        '    Dim cls As New WS_LGTFOOD.fafmtcd
        '    For Each sub_cls In WS_LGTFOOD.fafmtcd()
        '        main_class.fafmtcd.Add(sub_cls)
        '        cls = New WS_LGTFOOD.fafmtcd
        '    Next
        'End Sub
        Sub fagrpfd(ByRef main_class As MAIN_MASTER)
            Dim cls As New WS_LGTFOOD.fagrpfd
            For Each sub_cls In WS_LGTFOOD.fagrpfd()
                main_class.fagrpfd.Add(sub_cls)
                cls = New WS_LGTFOOD.fagrpfd
            Next
        End Sub
        Sub famthcd(ByRef main_class As MAIN_MASTER)
            Dim cls As New WS_LGTFOOD.famthcd
            For Each sub_cls In WS_LGTFOOD.famthcd()
                main_class.famthcd.Add(sub_cls)
                cls = New WS_LGTFOOD.famthcd
            Next
        End Sub
        Sub fdcancel(ByRef main_class As MAIN_MASTER)
            Dim cls As New WS_LGTFOOD.fdcancel
            For Each sub_cls In WS_LGTFOOD.fdcancel()
                main_class.fdcancel.Add(sub_cls)
                cls = New WS_LGTFOOD.fdcancel
            Next
        End Sub
        Sub frfdsubcd(ByRef main_class As MAIN_MASTER)
            Dim cls As New WS_LGTFOOD.frfdsubcd
            For Each sub_cls In WS_LGTFOOD.frfdsubcd()
                main_class.frfdsubcd.Add(sub_cls)
                cls = New WS_LGTFOOD.frfdsubcd
            Next
        End Sub
#End Region



    End Class
End Namespace
