Public Class MAIN_MASTER

#Region "Master"
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

#Region "DT_SYSISOCNT"
    Private _DT_SYSISOCNT As DataTable
    Public Property DT_SYSISOCNT() As DataTable
        Get
            Return _DT_SYSISOCNT
        End Get
        Set(ByVal value As DataTable)
            _DT_SYSISOCNT = value
        End Set
    End Property
#End Region

#Region "DT_SYSPDCFRGN"
    Private _DT_SYSPDCFRGN As DataTable
    Public Property DT_SYSPDCFRGN() As DataTable
        Get
            Return _DT_SYSPDCFRGN
        End Get
        Set(ByVal value As DataTable)
            _DT_SYSPDCFRGN = value
        End Set
    End Property
#End Region

#Region "สบ5"
#Region "fafdtype"
    Private _fafdtype As New List(Of WS_LGTFOOD.fafdtype)
    Public Property ws_fafdtype As List(Of WS_LGTFOOD.fafdtype)
        Get
            Return _fafdtype
        End Get
        Set(ByVal Value As List(Of WS_LGTFOOD.fafdtype))
            _fafdtype = Value
        End Set
    End Property
#End Region

#Region "fafmtcd"

    Private _fafmtcd As DataTable
    Public Property fafmtcd As DataTable
        Get
            Return _fafmtcd
        End Get
        Set(ByVal Value As DataTable)
            _fafmtcd = Value
        End Set
    End Property
    'Private _fafmtcd As New List(Of WS_LGTFOOD.fafmtcd)
    'Public Property fafmtcd As List(Of WS_LGTFOOD.fafmtcd)
    '    Get
    '        Return _fafmtcd
    '    End Get
    '    Set(ByVal Value As List(Of WS_LGTFOOD.fafmtcd))
    '        _fafmtcd = Value
    '    End Set
    'End Property
#End Region

#Region "fagrpfd"
    Private _fagrpfd As New List(Of WS_LGTFOOD.fagrpfd)
    Public Property fagrpfd As List(Of WS_LGTFOOD.fagrpfd)
        Get
            Return _fagrpfd
        End Get
        Set(ByVal Value As List(Of WS_LGTFOOD.fagrpfd))
            _fagrpfd = Value
        End Set
    End Property
#End Region

#Region "famthcd"
    Private _famthcd As New List(Of WS_LGTFOOD.famthcd)
    Public Property famthcd As List(Of WS_LGTFOOD.famthcd)
        Get
            Return _famthcd
        End Get
        Set(ByVal Value As List(Of WS_LGTFOOD.famthcd))
            _famthcd = Value
        End Set
    End Property

#End Region

#Region "fdcancel"
    Private _fdcancel As New List(Of WS_LGTFOOD.fdcancel)
    Public Property fdcancel As List(Of WS_LGTFOOD.fdcancel)
        Get
            Return _fdcancel
        End Get
        Set(ByVal Value As List(Of WS_LGTFOOD.fdcancel))
            _fdcancel = Value
        End Set
    End Property
#End Region

    '#Region "flfactstcd"
    '    Private _flfactstcd As New List(Of WS_LGTFOOD.flfactstcd)
    '    Public Property flfactstcd As List(Of WS_LGTFOOD.flfactstcd)
    '        Get
    '            Return _flfactstcd
    '        End Get
    '        Set(ByVal Value As List(Of WS_LGTFOOD.flfactstcd))
    '            _flfactstcd = Value
    '        End Set
    '    End Property
    '#End Region

    '#Region "fregntftpcd"
    '    Private _fregntftpcd As New List(Of WS_LGTFOOD.fregntftpcd)
    '    Public Property fregntftpcd As List(Of WS_LGTFOOD.fregntftpcd)
    '        Get
    '            Return _fregntftpcd
    '        End Get
    '        Set(ByVal Value As List(Of WS_LGTFOOD.fregntftpcd))
    '            _fregntftpcd = Value
    '        End Set
    '    End Property
    '#End Region

#Region "frfdsubcd"
    Private _frfdsubcd As New List(Of WS_LGTFOOD.frfdsubcd)
    Public Property frfdsubcd As List(Of WS_LGTFOOD.frfdsubcd)
        Get
            Return _frfdsubcd
        End Get
        Set(ByVal Value As List(Of WS_LGTFOOD.frfdsubcd))
            _frfdsubcd = Value
        End Set
    End Property
#End Region
#End Region
#End Region

#Region "Show"
    Private _Main_Person As New MainPerson
    Public Property Main_Person() As MainPerson
        Get
            Return _Main_Person
        End Get
        Set(ByVal value As MainPerson)
            _Main_Person = value
        End Set
    End Property

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

#Region "MainPerson"
    Private _MainPerson As New List(Of MainPerson)
    Public Property MainPerson As List(Of MainPerson)
        Get
            Return _MainPerson
        End Get
        Set(ByVal Value As List(Of MainPerson))
            _MainPerson = Value
        End Set
    End Property
#End Region

#Region "Person"
    Private _Person As New List(Of Person)
    Public Property Person As List(Of Person)
        Get
            Return _Person
        End Get
        Set(ByVal Value As List(Of Person))
            _Person = Value
        End Set
    End Property
#End Region

#Region "DT_COMPANY"
    Private _DT_COMPANY As DataTable
    Public Property DT_COMPANY() As DataTable
        Get
            Return _DT_COMPANY
        End Get
        Set(ByVal value As DataTable)
            _DT_COMPANY = value
        End Set
    End Property
#End Region
#End Region





End Class
