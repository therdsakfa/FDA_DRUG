''' <summary>
''' class Import / Export XML Placebo
''' </summary>
''' <remarks></remarks>
Public Class CLASS_DP
    Inherits CLASS_CENTER
    Public drpcbs As New drpcb
#Region "SHOW"
    Private _DT_SHOW As New CLS_SHOW
    Public Property DT_SHOW() As CLS_SHOW
        Get
            Return _DT_SHOW
        End Get
        Set(ByVal value As CLS_SHOW)
            _DT_SHOW = value
        End Set
    End Property
#End Region

#Region "MASTER"
    Private _DT_MASTER As New CLS_MASTER
    Public Property DT_MASTER() As CLS_MASTER
        Get
            Return _DT_MASTER
        End Get
        Set(ByVal value As CLS_MASTER)
            _DT_MASTER = value
        End Set
    End Property
#End Region

#Region "DataBase"


#Region "drpcbdrg"
    Private _drpcbdrg As New List(Of drpcbdrg)
    Public Property drpcbdrgs As List(Of drpcbdrg)
        Get
            Return _drpcbdrg
        End Get
        Set(ByVal Value As List(Of drpcbdrg))
            _drpcbdrg = Value
        End Set
    End Property
#End Region



#Region "drfrgn"
    Private _drfrgn As New List(Of drfrgn)
    Public Property drfrgns As List(Of drfrgn)
        Get
            Return _drfrgn
        End Get
        Set(ByVal Value As List(Of drfrgn))
            _drfrgn = Value
        End Set
    End Property
#End Region



#Region "drfrgnaddr"
    Private _drfrgnaddr As New List(Of drfrgnaddr)
    Public Property drfrgnaddrs As List(Of drfrgnaddr)
        Get
            Return _drfrgnaddr
        End Get
        Set(ByVal Value As List(Of drfrgnaddr))
            _drfrgnaddr = Value
        End Set
    End Property
#End Region



#Region "syspdcfrgn"
    Private _syspdcfrgn As New List(Of syspdcfrgn)
    Public Property syspdcfrgns As List(Of syspdcfrgn)
        Get
            Return _syspdcfrgn
        End Get
        Set(ByVal Value As List(Of syspdcfrgn))
            _syspdcfrgn = Value
        End Set
    End Property
#End Region

#End Region









End Class
