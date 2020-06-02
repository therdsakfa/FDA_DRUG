Public Class CLASS_DRRGT_SUB
    Inherits CLASS_CENTER
    Public DRRGT_SUBSTITUTEs As New DRRGT_SUBSTITUTE


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
    Private _TABEAN_FORMAT As String
    Public Property TABEAN_FORMAT() As String
        Get
            Return _TABEAN_FORMAT
        End Get
        Set(ByVal value As String)
            _TABEAN_FORMAT = value
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

    Private _RCVNO_FORMAT As String
    Public Property RCVNO_FORMAT() As String
        Get
            Return _RCVNO_FORMAT
        End Get
        Set(ByVal value As String)
            _RCVNO_FORMAT = value
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
    Private _DRUG_NAME As String
    Public Property DRUG_NAME() As String
        Get
            Return _DRUG_NAME
        End Get
        Set(ByVal value As String)
            _DRUG_NAME = value
        End Set
    End Property
    Private _rcvdate As String
    Public Property rcvdate() As String
        Get
            Return _rcvdate
        End Get
        Set(ByVal value As String)
            _rcvdate = value
        End Set
    End Property
    Private _TABEAN_TYPE1 As String
    Public Property TABEAN_TYPE1() As String
        Get
            Return _TABEAN_TYPE1
        End Get
        Set(ByVal value As String)
            _TABEAN_TYPE1 = value
        End Set
    End Property
    Private _TABEAN_TYPE2 As String
    Public Property TABEAN_TYPE2() As String
        Get
            Return _TABEAN_TYPE2
        End Get
        Set(ByVal value As String)
            _TABEAN_TYPE2 = value
        End Set
    End Property
    Private _CHK_LCN_SUBTYPE As String
    Public Property CHK_LCN_SUBTYPE() As String
        Get
            Return _CHK_LCN_SUBTYPE
        End Get
        Set(ByVal value As String)
            _CHK_LCN_SUBTYPE = value
        End Set
    End Property
    Private _LCN_NAME As String
    Public Property LCN_NAME() As String
        Get
            Return _LCN_NAME
        End Get
        Set(ByVal value As String)
            _LCN_NAME = value
        End Set
    End Property
#End Region
    'Private _DRRGT_EDIT_REQUEST_COLORs As New List(Of DRRGT_EDIT_REQUEST_COLOR)
    'Public Property DRRGT_EDIT_REQUEST_COLORs As List(Of DRRGT_EDIT_REQUEST_COLOR)
    '    Get
    '        Return _DRRGT_EDIT_REQUEST_COLORs
    '    End Get
    '    Set(ByVal Value As List(Of DRRGT_EDIT_REQUEST_COLOR))
    '        _DRRGT_EDIT_REQUEST_COLORs = Value
    '    End Set
    'End Property

End Class