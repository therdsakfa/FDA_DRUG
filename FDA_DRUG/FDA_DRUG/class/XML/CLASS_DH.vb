''' <summary>
''' class Import / Export XML เภสัชเคมีภัณฑ์
''' </summary>
''' <remarks></remarks>
Public Class CLASS_DH
    Inherits CLASS_CENTER
    Public dh15rqts As New dh15rqt

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
    Private _AGENT_COUNTRY_NAME As String
    Public Property AGENT_COUNTRY_NAME() As String
        Get
            Return _AGENT_COUNTRY_NAME
        End Get
        Set(ByVal value As String)
            _AGENT_COUNTRY_NAME = value
        End Set

    End Property
    'FOREIGN_COUNTRY
    Private _FOREIGN_COUNTRY_NAME As String
    Public Property FOREIGN_COUNTRY_NAME() As String
        Get
            Return _FOREIGN_COUNTRY_NAME
        End Get
        Set(ByVal value As String)
            _FOREIGN_COUNTRY_NAME = value
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

#Region "dh15tdgt"
    Private _dh15tdgt As New List(Of dh15tdgt)
    Public Property dh15tdgts As List(Of dh15tdgt)
        Get
            Return _dh15tdgt
        End Get
        Set(ByVal Value As List(Of dh15tdgt))
            _dh15tdgt = Value
        End Set
    End Property
#End Region

#Region "dh15tpdcfrgn"
    Private _dh15tpdcfrgn As New List(Of dh15tpdcfrgn)
    Public Property dh15tpdcfrgns As List(Of dh15tpdcfrgn)
        Get
            Return _dh15tpdcfrgn
        End Get
        Set(ByVal Value As List(Of dh15tpdcfrgn))
            _dh15tpdcfrgn = Value
        End Set
    End Property
#End Region

#Region "dh15frgn"
    Private _dh15frgn As New List(Of dh15frgn)
    Public Property dh15frgns As List(Of dh15frgn)
        Get
            Return _dh15frgn
        End Get
        Set(ByVal Value As List(Of dh15frgn))
            _dh15frgn = Value
        End Set
    End Property
#End Region

#Region "dh15rqtdt"
    Private _dh15rqtdt As New List(Of dh15rqtdt)
    Public Property dh15rqtdts As List(Of dh15rqtdt)
        Get
            Return _dh15rqtdt
        End Get
        Set(ByVal Value As List(Of dh15rqtdt))
            _dh15rqtdt = Value
        End Set
    End Property
#End Region

#Region "DH15_DETAIL_CER"
    Private _DH15_DETAIL_CER As New List(Of DH15_DETAIL_CER)
    Public Property DH15_DETAIL_CERs As List(Of DH15_DETAIL_CER)
        Get
            Return _DH15_DETAIL_CER
        End Get
        Set(ByVal Value As List(Of DH15_DETAIL_CER))
            _DH15_DETAIL_CER = Value
        End Set
    End Property
#End Region

#Region "DH15_DETAIL_CASCHEMICAL"
    Private _DH15_DETAIL_CASCHEMICAL As New List(Of DH15_DETAIL_CASCHEMICAL)
    Public Property DH15_DETAIL_CASCHEMICALs As List(Of DH15_DETAIL_CASCHEMICAL)
        Get
            Return _DH15_DETAIL_CASCHEMICAL
        End Get
        Set(ByVal Value As List(Of DH15_DETAIL_CASCHEMICAL))
            _DH15_DETAIL_CASCHEMICAL = Value
        End Set
    End Property
#End Region

#Region "DH15_DETAIL_MANUFACTURE"
    Private _DH15_DETAIL_MANUFACTURE As New List(Of DH15_DETAIL_MANUFACTURE)
    Public Property DH15_DETAIL_MANUFACTUREs As List(Of DH15_DETAIL_MANUFACTURE)
        Get
            Return _DH15_DETAIL_MANUFACTURE
        End Get
        Set(ByVal Value As List(Of DH15_DETAIL_MANUFACTURE))
            _DH15_DETAIL_MANUFACTURE = Value
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

    Private _URL_CHEMICAL_SEARCH As String
    Public Property URL_CHEMICAL_SEARCH() As String
        Get
            Return _URL_CHEMICAL_SEARCH
        End Get
        Set(ByVal value As String)
            _URL_CHEMICAL_SEARCH = value
        End Set
    End Property


End Class
