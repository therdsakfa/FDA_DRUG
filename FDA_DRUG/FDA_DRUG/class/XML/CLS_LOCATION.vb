Public Class CLS_LOCATION
    Inherits CLASS_CENTER
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

    'Public NCT_LCTADDRs As New NCT_LCTADDR

    Private _NCT_LCTADDRs As New LOCATION_ADDRESS
    Public Property NCT_LCTADDRs() As LOCATION_ADDRESS
        Get
            Return _NCT_LCTADDRs
        End Get
        Set(ByVal value As LOCATION_ADDRESS)
            _NCT_LCTADDRs = value
        End Set
    End Property

    Private _LOCATION_BSNs As New List(Of LOCATION_BSN)
    Public Property LOCATION_BSNs() As List(Of LOCATION_BSN)
        Get
            Return _LOCATION_BSNs
        End Get
        Set(ByVal value As List(Of LOCATION_BSN))
            _LOCATION_BSNs = value
        End Set
    End Property



#End Region




End Class
