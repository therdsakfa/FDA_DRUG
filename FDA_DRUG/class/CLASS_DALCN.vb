Public Class CLASS_DALCN
    Inherits MainPerson
    Public dalcn As New dalcn
   
#Region "dacnccs"

    Private _dacnccs As New List(Of dacncc)
    Public Property dacnccs() As List(Of dacncc)
        Get
            Return _dacnccs
        End Get
        Set(ByVal value As List(Of dacncc))
            _dacnccs = value
        End Set
    End Property
#End Region
#Region "dacnc"

    Private _dacnc As New List(Of dacnc)
    Public Property dacnc() As List(Of dacnc)
        Get
            Return _dacnc
        End Get
        Set(ByVal value As List(Of dacnc))
            _dacnc = value
        End Set
    End Property
#End Region

#Region "dalcntype"

    Private _dalcntype As New List(Of dalcntype)
    Public Property dalcntype() As List(Of dalcntype)
        Get
            Return _dalcntype
        End Get
        Set(ByVal value As List(Of dalcntype))
            _dalcntype = value
        End Set
    End Property
#End Region
#Region "dalcnphr"

    Private _dalcnphr As New List(Of dalcnphr)
    Public Property dalcnphr() As List(Of dalcnphr)
        Get
            Return _dalcnphr
        End Get
        Set(ByVal value As List(Of dalcnphr))
            _dalcnphr = value
        End Set
    End Property
#End Region
#Region "dalcnkep"

    Private _dalcnkep As New List(Of dalcnkep)
    Public Property dalcnkep() As List(Of dalcnkep)
        Get
            Return _dalcnkep
        End Get
        Set(ByVal value As List(Of dalcnkep))
            _dalcnkep = value
        End Set
    End Property
#End Region
#Region "daphrfunctcd"
    Private _daphrfunctcd As New List(Of WS_LGTDRUG.daphrfunctcd)
    Public Property daphrfunctcd As List(Of WS_LGTDRUG.daphrfunctcd)
        Get
            Return _daphrfunctcd
        End Get
        Set(ByVal Value As List(Of WS_LGTDRUG.daphrfunctcd))
            _daphrfunctcd = Value
        End Set
    End Property
#End Region

#Region "สถานที่เก็บ"
    Public sysplace As New sysplace
#End Region

#Region "syschngwt"

    Private _syschngwt As New List(Of WS_CENTER.syschngwt)
    Public Property syschngwt() As List(Of WS_CENTER.syschngwt)
        Get
            Return _syschngwt
        End Get
        Set(ByVal value As List(Of WS_CENTER.syschngwt))
            _syschngwt = value
        End Set
    End Property
#End Region

#Region "sysamphr"
    Private _sysamphr As New List(Of WS_CENTER.sysamphr)
    Public Property sysamphr As List(Of WS_CENTER.sysamphr)
        Get
            Return _sysamphr
        End Get
        Set(ByVal Value As List(Of WS_CENTER.sysamphr))
            _sysamphr = Value
        End Set
    End Property
#End Region

#Region "systhmbl"
    Private _systhmbl As New List(Of WS_CENTER.systhmbl)
    Public Property systhmbl As List(Of WS_CENTER.systhmbl)
        Get
            Return _systhmbl
        End Get
        Set(ByVal Value As List(Of WS_CENTER.systhmbl))
            _systhmbl = Value
        End Set
    End Property
#End Region



#Region "MainCompany"
    Private _MainCompany As New List(Of MainCompany)
    Public Property MainCompany As List(Of MainCompany)
        Get
            Return _MainCompany
        End Get
        Set(ByVal Value As List(Of MainCompany))
            _MainCompany = Value
        End Set
    End Property
#End Region


End Class
