Public Class XML_LICENSE_LOCATION
    Inherits CLASS_CENTER
#Region "SHOW"
    Private _DT_SHOW As New CLS_SHOW_DATA
    Public Property DT_SHOW() As CLS_SHOW_DATA
        Get
            Return _DT_SHOW
        End Get
        Set(ByVal value As CLS_SHOW_DATA)
            _DT_SHOW = value
        End Set
    End Property


#End Region

#Region "MASTER"
    Private _DT_MASTER As New CLS_MASTER_DATA
    Public Property DT_MASTER() As CLS_MASTER_DATA
        Get
            Return _DT_MASTER
        End Get
        Set(ByVal value As CLS_MASTER_DATA)
            _DT_MASTER = value
        End Set
    End Property
#End Region

#Region "IMAGE"
    Private _IMAGE As New CLS_IMAGE_DATA
    Public Property IMAGE() As CLS_IMAGE_DATA
        Get
            Return _IMAGE
        End Get
        Set(ByVal value As CLS_IMAGE_DATA)
            _IMAGE = value
        End Set
    End Property
#End Region


#Region "DB"

    Public LICENSE_LOCATIONs As New LICENSE_LOCATION

    Private _HOSPITAL_LOCATIONs As New List(Of HOSPITAL_LOCATION)
    Public Property HOSPITAL_LOCATIONs() As List(Of HOSPITAL_LOCATION)
        Get
            Return _HOSPITAL_LOCATIONs
        End Get
        Set(ByVal value As List(Of HOSPITAL_LOCATION))
            _HOSPITAL_LOCATIONs = value
        End Set
    End Property

#End Region

#Region "detail"
    Private _PDF_VERSION As String
    Public Property PDF_VERSION() As String
        Get
            Return _PDF_VERSION
        End Get
        Set(ByVal value As String)
            _PDF_VERSION = value
        End Set
    End Property
#End Region

End Class
