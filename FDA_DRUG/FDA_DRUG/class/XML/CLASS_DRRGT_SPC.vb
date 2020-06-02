Public Class CLASS_DRRGT_SPC
    Inherits CLASS_CENTER
    Public DRRGT_SPCs As New DRRGT_SPC


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
    Private _DRUG_NAME_TH As String
    Public Property DRUG_NAME_TH() As String
        Get
            Return _DRUG_NAME_TH
        End Get
        Set(ByVal value As String)
            _DRUG_NAME_TH = value
        End Set
    End Property
    Private _DRUG_NAME_ENG As String
    Public Property DRUG_NAME_ENG() As String
        Get
            Return _DRUG_NAME_ENG
        End Get
        Set(ByVal value As String)
            _DRUG_NAME_ENG = value
        End Set
    End Property
    Private _TR_ID_SHOW As String
    Public Property TR_ID_SHOW() As String
        Get
            Return _TR_ID_SHOW
        End Get
        Set(ByVal value As String)
            _TR_ID_SHOW = value
        End Set
    End Property
    Private _DRUG_NAME As String
    Public Property DRUG_NAME() As String
        Get
            Return _DRUG_NAME
        End Get
        Set(ByVal value As String)
            _DRUG_NAME = value
        End Set
    End Property
    Private _LCNNO_FORMAT As String
    Public Property LCNNO_FORMAT() As String
        Get
            Return _LCNNO_FORMAT
        End Get
        Set(ByVal value As String)
            _LCNNO_FORMAT = value
        End Set
    End Property
    Private _RGTNO_FORMAT As String
    Public Property RGTNO_FORMAT() As String
        Get
            Return _RGTNO_FORMAT
        End Get
        Set(ByVal value As String)
            _RGTNO_FORMAT = value
        End Set
    End Property
End Class