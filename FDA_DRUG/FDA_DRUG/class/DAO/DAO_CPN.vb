Namespace DAO_CPN


    Public MustInherit Class MAINCONTEXT1
        Public db_cpn As New Linq_CPNDataContext

        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class

#Region "CPN"
    Public Class clsDBsyslcnsid
        Inherits MAINCONTEXT1
        Public fields As New syslcnsid
        Public Sub insert()
            db_cpn.syslcnsids.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.syslcnsids.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.syslcnsids Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.syslcnsids Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_taxno(ByVal taxno As String)
            datas = (From p In db_cpn.syslcnsids Where p.taxno = taxno Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_identify(ByVal identify As String)
            datas = (From p In db_cpn.syslcnsids Where p.identify = identify Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class clsDBsyslctnm
        Inherits MAINCONTEXT1
        Public fields As New syslctnm
        Public Sub insert()
            db_Cpn.syslctnms.InsertOnSubmit(fields)
            db_Cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_Cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_Cpn.syslctnms.DeleteOnSubmit(fields)
            db_Cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_Cpn.syslctnms Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.syslctnms Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class clsDBsyslcnsnm
        Inherits MAINCONTEXT1
        Public fields As New syslcnsnm
        Public Sub insert()
            db_cpn.syslcnsnms.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.syslcnsnms.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.syslcnsnms Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.syslcnsnms Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_identify(ByVal identify As String)
            datas = (From p In db_cpn.syslcnsnms Where p.identify = identify Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_thanm(ByVal thanm As String)
            datas = (From p In db_cpn.syslcnsnms Where p.thanm = thanm Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDatabysearch_thanm(ByVal thanm As String)
            datas = (From p In db_cpn.syslcnsnms Where p.thanm Like "%" & thanm & "%" Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class clsDBsysusrid
        Inherits MAINCONTEXT1
        Public fields As New sysusrid
        Public Sub insert()
            db_cpn.sysusrids.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.sysusrids.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.sysusrids Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.sysusrids Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_User_pwd(ByVal user As String, ByVal pwd As String)
            datas = (From p In db_cpn.sysusrids Where p.usrid = user And p.pwd = pwd Select p)
            For Each Me.fields In datas
            Next
        End Sub


    End Class

    Public Class clsDBsyslctaddr
        Inherits MAINCONTEXT1
        Public fields As New syslctaddr
        Public Sub insert()
            db_Cpn.syslctaddrs.InsertOnSubmit(fields)
            db_Cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_Cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_Cpn.syslctaddrs.DeleteOnSubmit(fields)
            db_Cpn.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db_Cpn.syslctaddrs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.syslctaddrs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_identify(ByVal identify As String)
            datas = (From p In db_cpn.syslctaddrs Where p.identify = identify Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid_lctcd(ByVal lcnsid As Integer, ByVal lctcd As Integer)
            datas = (From p In db_cpn.syslctaddrs Where p.lcnsid = lcnsid And p.lctcd = lctcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class clsDBfdasysaddrhn
        Inherits MAINCONTEXT1
        Public fields As New fda_sysaddrhn

        Public Sub insert()
            db_cpn.fda_sysaddrhns.InsertOnSubmit(fields)
            db_Cpn.SubmitChanges()
        End Sub

        Public Sub update()
            db_Cpn.SubmitChanges()
        End Sub

        Public Sub delete()
            db_cpn.fda_sysaddrhns.DeleteOnSubmit(fields)
            db_Cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.fda_sysaddrhns Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.fda_sysaddrhns Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Houseno(ByVal houseno As String)
            datas = (From p In db_cpn.fda_sysaddrhns Where p.houseno = houseno Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class clsDBsyschngwt
        Inherits MAINCONTEXT1
        Public fields As New syschngwt
        Public Sub insert()
            db_cpn.syschngwts.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.syschngwts.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.syschngwts Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_chngwtcd(ByVal chngwtcd As Integer)
            datas = (From p In db_cpn.syschngwts Where p.chngwtcd = chngwtcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_thacwabbr(ByVal thacwabbr As String)
            datas = (From p In db_cpn.syschngwts Where p.thacwabbr = thacwabbr Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class clsDBsysamphr
        Inherits MAINCONTEXT1
        Public fields As New sysamphr
        Public Sub insert()
            db_cpn.sysamphrs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.sysamphrs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.sysamphrs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_chngwtcd_amphrcd(ByVal chngwtcd As Integer, ByVal amphrcd As Integer)
            datas = (From p In db_cpn.sysamphrs Where p.chngwtcd = chngwtcd And p.amphrcd = amphrcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_chngwtcd(ByVal chngwtcd As Integer)
            datas = (From p In db_cpn.sysamphrs Where p.chngwtcd = chngwtcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_chngwtcd(ByVal chngwtcd As Integer)

            datas = (From p In db_cpn.sysamphrs Where p.chngwtcd = chngwtcd Order By p.thaamphrnm Select p)
            For Each Me.fields In datas

            Next

        End Sub
    End Class
    Public Class clsDBsysthmbl
        Inherits MAINCONTEXT1
        Public fields As New systhmbl
        Public Sub insert()
            db_cpn.systhmbls.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.systhmbls.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.systhmbls Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetData_by_chngwtcd_amphrcd_thmblcd(ByVal chngwtcd As Integer, ByVal amphrcd As Integer, ByVal thmblcd As Integer)
            datas = (From p In db_cpn.systhmbls Where p.chngwtcd = chngwtcd And p.amphrcd = amphrcd And p.thmblcd = thmblcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_chngwtcd_amphrcd(ByVal chngwtcd As Integer, ByVal amphrcd As Integer)
            datas = (From p In db_cpn.systhmbls Where p.chngwtcd = chngwtcd And p.amphrcd = amphrcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_thmbl(ByVal chngwtcd As Integer, ByVal amphrcd As Integer)

            datas = (From p In db_cpn.systhmbls Order By p.thathmblnm Ascending Where p.chngwtcd = chngwtcd And p.amphrcd = amphrcd Order By p.thathmblnm Select p)
            For Each Me.fields In datas

            Next

        End Sub
    End Class
    Public Class tb_lcnsid
        Inherits MAINCONTEXT1
        Public fields As New syslcnsid

        Public Sub delete()
            db_cpn.syslcnsids.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub insert()
            db_cpn.syslcnsids.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetData_ByID(ByVal ida As Integer)
            datas = (From p In db_cpn.syslcnsids Where p.IDA = ida Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetDataby_lcnid(ByVal lcnid As String)
            datas = (From p In db_cpn.syslcnsids Where p.identify = lcnid Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetData_ByIdentify(ByVal identify As String)
            datas = (From p In db_cpn.syslcnsids Where p.identify = identify Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
   
  
    Public Class clsDBSYSTEM_NAME
        Inherits MAINCONTEXT1
        Public fields As New SYSTEM_NAME
        Public Sub insert()
            db_cpn.SYSTEM_NAMEs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.SYSTEM_NAMEs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.SYSTEM_NAMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_ID(ByVal ID As Integer)
            datas = (From p In db_cpn.SYSTEM_NAMEs Where p.SYSTEM_ID = ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class clsDBsysnmperson
        Inherits MAINCONTEXT1
        Public fields As New sysnmperson

        Public Sub insert()
            db_cpn.sysnmpersons.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub

        Public Sub delete()
            db_cpn.sysnmpersons.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.sysnmpersons Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_identify(ByVal identify As String)
            datas = (From p In db_cpn.sysnmpersons Where p.identify = identify Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.sysnmpersons Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

 
  
#End Region



    Public Class TB_LOCATION_ADDRESS
        Inherits MAINCONTEXT1
        Public fields As New LOCATION_ADDRESS
        Public Sub insert()
            db_cpn.LOCATION_ADDRESSes.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.LOCATION_ADDRESSes.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.LOCATION_ADDRESSes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.LOCATION_ADDRESSes Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_identify(ByVal iden As String)
            datas = (From p In db_cpn.LOCATION_ADDRESSes Where p.IDENTIFY = iden Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db_cpn.LOCATION_ADDRESSes Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid_lctcd(ByVal lcnsid As Integer, ByVal lctcd As Integer)
            datas = (From p In db_cpn.LOCATION_ADDRESSes Where p.lcnsid = lcnsid And p.lctcd = lctcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class TB_LOCATION_DETAIL
        Inherits MAINCONTEXT1
        Public fields As New LOCATION_DETAIL
        Public Sub insert()
            db_cpn.LOCATION_DETAILs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.LOCATION_DETAILs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.LOCATION_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.LOCATION_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db_cpn.LOCATION_DETAILs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_LOCATION_BSN
        Inherits MAINCONTEXT1 : Implements MAINCONTEXT1.MAIN
        Public fields As New LOCATION_BSN
        Private _Details As New List(Of LOCATION_BSN)
        Public Property Details() As List(Of LOCATION_BSN)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of LOCATION_BSN))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New LOCATION_BSN
        End Sub
        Public Sub delete() Implements MAINCONTEXT1.MAIN.delete
            db_cpn.LOCATION_BSNs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub insert() Implements MAINCONTEXT1.MAIN.insert
            db_cpn.LOCATION_BSNs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub update() Implements MAINCONTEXT1.MAIN.update
            db_cpn.SubmitChanges()
        End Sub

        Public Sub Getdata_byid(ByVal id As Integer)
            datas = (From q In db_cpn.LOCATION_BSNs Where q.IDA = id Select q)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdata_by_fk_id(ByVal fk_id As Integer)
            datas = (From q In db_cpn.LOCATION_BSNs Where q.FK_IDA = fk_id Select q)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        Public Sub Getdata_by_iden(ByVal iden As String)
            datas = (From q In db_cpn.LOCATION_BSNs Where q.BSN_IDENTIFY = iden Select q)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_fk_id2(ByVal fk_id As Integer)
            datas = (From q In db_cpn.LOCATION_BSNs Where q.FK_IDA = fk_id Select q)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_bsnid(ByVal bsnid As Integer)
            datas = (From q In db_cpn.LOCATION_BSNs Where q.BSNID = bsnid Select q)
            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class TB_sysprefix
        Inherits MAINCONTEXT1 : Implements MAINCONTEXT1.MAIN
        Public fields As New sysprefix
        Private _Details As New List(Of sysprefix)
        Public Property Details() As List(Of sysprefix)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of sysprefix))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New sysprefix
        End Sub
        Public Sub delete() Implements MAINCONTEXT1.MAIN.delete
            db_cpn.sysprefixes.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub insert() Implements MAINCONTEXT1.MAIN.insert
            db_cpn.sysprefixes.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub update() Implements MAINCONTEXT1.MAIN.update
            db_cpn.SubmitChanges()
        End Sub

        Public Sub Getdata_byid(ByVal id As Integer)
            datas = (From q In db_cpn.sysprefixes Where q.prefixcd = id Select q)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_sysemail
        Inherits MAINCONTEXT1
        Public fields As New sysemail

        Public Sub insert()
            db_CPN.sysemails.InsertOnSubmit(fields)
            db_CPN.SubmitChanges()
        End Sub
        Public Sub update()
            db_CPN.SubmitChanges()
        End Sub

        Public Sub delete()
            db_CPN.sysemails.DeleteOnSubmit(fields)
            db_CPN.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db_CPN.sysemails Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_CITIZEN_ID(ByVal CITIZEN_ID As String)
            datas = (From p In db_CPN.sysemails Where p.CITIZEN_ID = CITIZEN_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_syslcnsnm
        Inherits MAINCONTEXT1
        Public fields As New syslcnsnm

        Public Sub insert()
            db_CPN.syslcnsnms.InsertOnSubmit(fields)
            db_CPN.SubmitChanges()
        End Sub
        Public Sub update()
            db_CPN.SubmitChanges()
        End Sub

        Public Sub delete()
            db_CPN.syslcnsnms.DeleteOnSubmit(fields)
            db_CPN.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db_CPN.syslcnsnms Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_identify(ByVal identify As String)
            datas = (From p In db_CPN.syslcnsnms Where p.identify = identify Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_thanm(ByVal thanm As String)
            datas = (From p In db_CPN.syslcnsnms Where p.thanm = thanm Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
End Namespace

