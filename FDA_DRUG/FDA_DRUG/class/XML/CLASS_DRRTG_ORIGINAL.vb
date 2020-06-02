Public Class CLASS_DRRTG_ORIGINAL
    Public drrgts As New drrgt

    Private _DRRGT_ATC_DETAILs As New List(Of DRRGT_ATC_DETAIL)
    Public Property DRRGT_ATC_DETAILs As List(Of DRRGT_ATC_DETAIL)
        Get
            Return _DRRGT_ATC_DETAILs
        End Get
        Set(ByVal Value As List(Of DRRGT_ATC_DETAIL))
            _DRRGT_ATC_DETAILs = Value
        End Set
    End Property

    Private _DRRGT_COLORs As New List(Of DRRGT_COLOR)
    Public Property DRRGT_COLORs As List(Of DRRGT_COLOR)
        Get
            Return _DRRGT_COLORs
        End Get
        Set(ByVal Value As List(Of DRRGT_COLOR))
            _DRRGT_COLORs = Value
        End Set
    End Property

    Private _DRRGT_CONDITIONs As New List(Of DRRGT_CONDITION)
    Public Property DRRGT_CONDITIONs As List(Of DRRGT_CONDITION)
        Get
            Return _DRRGT_CONDITIONs
        End Get
        Set(ByVal Value As List(Of DRRGT_CONDITION))
            _DRRGT_CONDITIONs = Value
        End Set
    End Property

    Private _DRRGT_DETAIL_CAs As New List(Of DRRGT_DETAIL_CA)
    Public Property DRRGT_DETAIL_CAs As List(Of DRRGT_DETAIL_CA)
        Get
            Return _DRRGT_DETAIL_CAs
        End Get
        Set(ByVal Value As List(Of DRRGT_DETAIL_CA))
            _DRRGT_DETAIL_CAs = Value
        End Set
    End Property

    Private _DRRGT_DTBs As New List(Of DRRGT_DTB)
    Public Property DRRGT_DTBs As List(Of DRRGT_DTB)
        Get
            Return _DRRGT_DTBs
        End Get
        Set(ByVal Value As List(Of DRRGT_DTB))
            _DRRGT_DTBs = Value
        End Set
    End Property

    Private _DRRGT_DTL_TEXTs As New List(Of DRRGT_DTL_TEXT)
    Public Property DRRGT_DTL_TEXTs As List(Of DRRGT_DTL_TEXT)
        Get
            Return _DRRGT_DTL_TEXTs
        End Get
        Set(ByVal Value As List(Of DRRGT_DTL_TEXT))
            _DRRGT_DTL_TEXTs = Value
        End Set
    End Property

    Private _DRRGT_EACHes As New List(Of DRRGT_EACH)
    Public Property DRRGT_EACHes As List(Of DRRGT_EACH)
        Get
            Return _DRRGT_EACHes
        End Get
        Set(ByVal Value As List(Of DRRGT_EACH))
            _DRRGT_EACHes = Value
        End Set
    End Property

    Private _DRRGT_EQTOs As New List(Of DRRGT_EQTO)
    Public Property DRRGT_EQTOs As List(Of DRRGT_EQTO)
        Get
            Return _DRRGT_EQTOs
        End Get
        Set(ByVal Value As List(Of DRRGT_EQTO))
            _DRRGT_EQTOs = Value
        End Set
    End Property

    Private _DRRGT_KEEP_DRUGs As New List(Of DRRGT_KEEP_DRUG)
    Public Property DRRGT_KEEP_DRUGs As List(Of DRRGT_KEEP_DRUG)
        Get
            Return _DRRGT_KEEP_DRUGs
        End Get
        Set(ByVal Value As List(Of DRRGT_KEEP_DRUG))
            _DRRGT_KEEP_DRUGs = Value
        End Set
    End Property

    Private _DRRGT_NO_USEs As New List(Of DRRGT_NO_USE)
    Public Property DRRGT_NO_USEs As List(Of DRRGT_NO_USE)
        Get
            Return _DRRGT_NO_USEs
        End Get
        Set(ByVal Value As List(Of DRRGT_NO_USE))
            _DRRGT_NO_USEs = Value
        End Set
    End Property

    Private _DRRGT_PACKAGE_DETAILs As New List(Of DRRGT_PACKAGE_DETAIL)
    Public Property DRRGT_PACKAGE_DETAILs As List(Of DRRGT_PACKAGE_DETAIL)
        Get
            Return _DRRGT_PACKAGE_DETAILs
        End Get
        Set(ByVal Value As List(Of DRRGT_PACKAGE_DETAIL))
            _DRRGT_PACKAGE_DETAILs = Value
        End Set
    End Property

    Private _DRRGT_PRODUCERs As New List(Of DRRGT_PRODUCER)
    Public Property DRRGT_PRODUCERs As List(Of DRRGT_PRODUCER)
        Get
            Return _DRRGT_PRODUCERs
        End Get
        Set(ByVal Value As List(Of DRRGT_PRODUCER))
            _DRRGT_PRODUCERs = Value
        End Set
    End Property

    Private _DRRGT_PRODUCER_INs As New List(Of DRRGT_PRODUCER_IN)
    Public Property DRRGT_PRODUCER_INs As List(Of DRRGT_PRODUCER_IN)
        Get
            Return _DRRGT_PRODUCER_INs
        End Get
        Set(ByVal Value As List(Of DRRGT_PRODUCER_IN))
            _DRRGT_PRODUCER_INs = Value
        End Set
    End Property

    Private _DRRGT_PROPERTIES_AND_DETAILs As New List(Of DRRGT_PROPERTIES_AND_DETAIL)
    Public Property DRRGT_PROPERTIES_AND_DETAILs As List(Of DRRGT_PROPERTIES_AND_DETAIL)
        Get
            Return _DRRGT_PROPERTIES_AND_DETAILs
        End Get
        Set(ByVal Value As List(Of DRRGT_PROPERTIES_AND_DETAIL))
            _DRRGT_PROPERTIES_AND_DETAILs = Value
        End Set
    End Property

    Private _DRRGT_PROPERTies As New List(Of DRRGT_PROPERTy)
    Public Property DRRGT_PROPERTies As List(Of DRRGT_PROPERTy)
        Get
            Return _DRRGT_PROPERTies
        End Get
        Set(ByVal Value As List(Of DRRGT_PROPERTy))
            _DRRGT_PROPERTies = Value
        End Set
    End Property
End Class
