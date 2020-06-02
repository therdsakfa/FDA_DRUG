Public Class CLASS_PHARMACIST
    Inherits CLASS_CENTER
    Public DALCN_PHRs As New DALCN_PHR
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

#Region "dakeplctnm"
        Private _dakeplctnm As New List(Of dakeplctnm)
        Public Property dakeplctnms As List(Of dakeplctnm)
            Get
                Return _dakeplctnm
            End Get
            Set(ByVal Value As List(Of dakeplctnm))
                _dakeplctnm = Value
            End Set
        End Property
#End Region

#Region "DALCN_WORKTIME"
        Private _DALCN_WORKTIME As New List(Of DALCN_WORKTIME)
        Public Property DALCN_WORKTIMEs As List(Of DALCN_WORKTIME)
            Get
                Return _DALCN_WORKTIME
            End Get
            Set(ByVal Value As List(Of DALCN_WORKTIME))
                _DALCN_WORKTIME = Value
            End Set
        End Property
#End Region

#Region "sysplace"
        Private _sysplace As New List(Of sysplace)
        Public Property sysplaces As List(Of sysplace)
            Get
                Return _sysplace
            End Get
            Set(ByVal Value As List(Of sysplace))
                _sysplace = Value
            End Set
        End Property
#End Region

#Region "dalcnaddr"
        Private _dalcnaddr As New List(Of dalcnaddr)
        Public Property dalcnaddrs As List(Of dalcnaddr)
            Get
                Return _dalcnaddr
            End Get
            Set(ByVal Value As List(Of dalcnaddr))
                _dalcnaddr = Value
            End Set
        End Property
#End Region


#End Region

    End Class
