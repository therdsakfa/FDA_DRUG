Public Class CLASS_LCNREQUEST
    Public LCNREQUESTs As New lcnrequest
    Public dalcns As New dalcn
    Public dalcns_new As New dalcn
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

#Region "dalcn"
    Private _dalcn As New List(Of dalcn)
    Public Property _dalcns As List(Of dalcn)
        Get
            Return _dalcn
        End Get
        Set(ByVal Value As List(Of dalcn))
            _dalcn = Value
        End Set
    End Property
#End Region
#Region "DataBase"
    Private _AUTO_ID As String
    Public Property AUTO_ID() As String
        Get
            Return _AUTO_ID
        End Get
        Set(ByVal value As String)
            _AUTO_ID = value
        End Set
    End Property

#End Region

    Private _DOWNLOAD_ID As String
    Public Property DOWNLOAD_ID() As String
        Get
            Return _DOWNLOAD_ID
        End Get
        Set(ByVal value As String)
            _DOWNLOAD_ID = value
        End Set
    End Property
    '
    Private _EXP_YEAR As String
    Public Property EXP_YEAR() As String
        Get
            Return _EXP_YEAR
        End Get
        Set(ByVal value As String)
            _EXP_YEAR = value
        End Set
    End Property
    Private _EXP_NEWYEAR As String
    Public Property EXP_NEWYEAR() As String
        Get
            Return _EXP_NEWYEAR
        End Get
        Set(ByVal value As String)
            _EXP_NEWYEAR = value
        End Set
    End Property
    Private _LCNNO_SHOW As String
    Public Property LCNNO_SHOW() As String
        Get
            Return _LCNNO_SHOW
        End Get
        Set(ByVal value As String)
            _LCNNO_SHOW = value
        End Set
    End Property

    Private _RCVDAY As String
    Public Property RCVDAY() As String
        Get
            Return _RCVDAY
        End Get
        Set(ByVal value As String)
            _RCVDAY = value
        End Set
    End Property

    Private _CHK_TYPE As String
    Public Property CHK_TYPE() As String
        Get
            Return _CHK_TYPE
        End Get
        Set(ByVal value As String)
            _CHK_TYPE = value
        End Set
    End Property

    Private _CHK_NAME As String
    Public Property CHK_NAME() As String
        Get
            Return _CHK_NAME
        End Get
        Set(ByVal value As String)
            _CHK_NAME = value
        End Set
    End Property

    Private _RCVMONTH As String
    Public Property RCVMONTH() As String
        Get
            Return _RCVMONTH
        End Get
        Set(ByVal value As String)
            _RCVMONTH = value
        End Set
    End Property

    Private _RCVYEAR As String
    Public Property RCVYEAR() As String
        Get
            Return _RCVYEAR
        End Get
        Set(ByVal value As String)
            _RCVYEAR = value
        End Set
    End Property
End Class
