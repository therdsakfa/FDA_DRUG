''' <summary>
''' class Import / Export XML นยม
''' </summary>
''' <remarks></remarks>
Public Class CLASS_DI
    Inherits CLASS_CENTER
    Public drimpfors As New drimpfor
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


#Region "drimpdrg"
    Private _drimpdrg As New List(Of drimpdrg)
    Public Property drimpdrgs As List(Of drimpdrg)
        Get
            Return _drimpdrg
        End Get
        Set(ByVal Value As List(Of drimpdrg))
            _drimpdrg = Value
        End Set
    End Property
#End Region


#Region "drimpfrgn"
    Private _drimpfrgn As New List(Of drimpfrgn)
    Public Property drimpfrgns As List(Of drimpfrgn)
        Get
            Return _drimpfrgn
        End Get
        Set(ByVal Value As List(Of drimpfrgn))
            _drimpfrgn = Value
        End Set
    End Property
#End Region

#Region "CER_DETAIL_CASCHEMICAL"
    Private _CER_DETAIL_CASCHEMICAL As New List(Of CER_DETAIL_CASCHEMICAL)
    Public Property CER_DETAIL_CASCHEMICAL As List(Of CER_DETAIL_CASCHEMICAL)
        Get
            Return _CER_DETAIL_CASCHEMICAL
        End Get
        Set(ByVal Value As List(Of CER_DETAIL_CASCHEMICAL))
            _CER_DETAIL_CASCHEMICAL = Value
        End Set
    End Property
#End Region

#Region "CER_DETAIL_MANUFACTURE"
    Private _CER_DETAIL_MANUFACTURE As New List(Of CER_DETAIL_MANUFACTURE)
    Public Property CER_DETAIL_MANUFACTURE As List(Of CER_DETAIL_MANUFACTURE)
        Get
            Return _CER_DETAIL_MANUFACTURE
        End Get
        Set(ByVal Value As List(Of CER_DETAIL_MANUFACTURE))
            _CER_DETAIL_MANUFACTURE = Value
        End Set
    End Property
#End Region



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

    Private _VERTION_PDF As String
    Public Property VERTION_PDF() As String
        Get
            Return _VERTION_PDF
        End Get
        Set(ByVal value As String)
            _VERTION_PDF = value
        End Set
    End Property
End Class
