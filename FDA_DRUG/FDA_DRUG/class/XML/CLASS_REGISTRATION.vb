Public Class CLASS_REGISTRATION
    Inherits CLASS_CENTER
    Public DRUG_REGISTRATIONs As New DRUG_REGISTRATION
    Public DRUG_REGISTRATION_COLORs As New DRUG_REGISTRATION_COLOR
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

#Region "DRUG_REGISTRATION_ATC_DETAIL"
    Private _DRUG_REGISTRATION_ATC_DETAIL As New List(Of DRUG_REGISTRATION_ATC_DETAIL)
    Public Property DRUG_REGISTRATION_ATC_DETAILs As List(Of DRUG_REGISTRATION_ATC_DETAIL)
        Get
            Return _DRUG_REGISTRATION_ATC_DETAIL
        End Get
        Set(ByVal Value As List(Of DRUG_REGISTRATION_ATC_DETAIL))
            _DRUG_REGISTRATION_ATC_DETAIL = Value
        End Set
    End Property
#End Region

#Region "DRUG_REGISTRATION_PACKAGE_DETAIL"
    Private _DRUG_REGISTRATION_PACKAGE_DETAIL As New List(Of DRUG_REGISTRATION_PACKAGE_DETAIL)
    Public Property DRUG_REGISTRATION_PACKAGE_DETAILs As List(Of DRUG_REGISTRATION_PACKAGE_DETAIL)
        Get
            Return _DRUG_REGISTRATION_PACKAGE_DETAIL
        End Get
        Set(ByVal Value As List(Of DRUG_REGISTRATION_PACKAGE_DETAIL))
            _DRUG_REGISTRATION_PACKAGE_DETAIL = Value
        End Set
    End Property
#End Region
#Region "DRUG_REGISTRATION_PROPERTIES"
    Private _DRUG_REGISTRATION_PROPERTy As New List(Of DRUG_REGISTRATION_PROPERTy)
    Public Property DRUG_REGISTRATION_PROPERTy As List(Of DRUG_REGISTRATION_PROPERTy)
        Get
            Return _DRUG_REGISTRATION_PROPERTy
        End Get
        Set(ByVal Value As List(Of DRUG_REGISTRATION_PROPERTy))
            _DRUG_REGISTRATION_PROPERTy = Value
        End Set
    End Property
#End Region
#Region "DRUG_REGISTRATION_PRODUCER"
    Private _DRUG_REGISTRATION_PRODUCER As New List(Of DRUG_REGISTRATION_PRODUCER)
    Public Property DRUG_REGISTRATION_PRODUCER As List(Of DRUG_REGISTRATION_PRODUCER)
        Get
            Return _DRUG_REGISTRATION_PRODUCER
        End Get
        Set(ByVal Value As List(Of DRUG_REGISTRATION_PRODUCER))
            _DRUG_REGISTRATION_PRODUCER = Value
        End Set
    End Property
#End Region
    '
#Region "DRUG_REGISTRATION_DETAIL_CAS"
    Private _DRUG_REGISTRATION_DETAIL_CA As New List(Of DRUG_REGISTRATION_DETAIL_CA)
    Public Property DRUG_REGISTRATION_DETAIL_CA As List(Of DRUG_REGISTRATION_DETAIL_CA)
        Get
            Return _DRUG_REGISTRATION_DETAIL_CA
        End Get
        Set(ByVal Value As List(Of DRUG_REGISTRATION_DETAIL_CA))
            _DRUG_REGISTRATION_DETAIL_CA = Value
        End Set
    End Property
#End Region

#Region "DRUG_REGISTRATION_COLOR"
    Private _DRUG_REGISTRATION_COLOR As New List(Of DRUG_REGISTRATION_COLOR)
    Public Property DRUG_REGISTRATION_COLOR As List(Of DRUG_REGISTRATION_COLOR)
        Get
            Return _DRUG_REGISTRATION_COLOR
        End Get
        Set(ByVal Value As List(Of DRUG_REGISTRATION_COLOR))
            _DRUG_REGISTRATION_COLOR = Value
        End Set
    End Property
#End Region
End Class
