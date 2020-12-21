Public Class CLASS_NYM_2
    Inherits CLASS_CENTER
    Public NYM_2s As New FDA_DRUG_IMPORT_NYM_2

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

#Region "additional"
    Private _REMARK As String
    Public Property REMARK() As String
        Get
            Return _REMARK
        End Get
        Set(ByVal value As String)
            _REMARK = value
        End Set
    End Property
    Private _DRUG_COLOR As String
    Public Property DRUG_COLOR() As String
        Get
            Return _DRUG_COLOR
        End Get
        Set(ByVal value As String)
            _DRUG_COLOR = value
        End Set
    End Property

    Private _CHK_TYPE_LCN As String
    Public Property CHK_TYPE_LCN() As String
        Get
            Return _CHK_TYPE_LCN
        End Get
        Set(ByVal value As String)
            _CHK_TYPE_LCN = value
        End Set
    End Property
    Private _PACK_SIZE As String
    Public Property PACK_SIZE() As String
        Get
            Return _PACK_SIZE
        End Get
        Set(ByVal value As String)
            _PACK_SIZE = value
        End Set
    End Property
    Private _SMALL_UNIT As String
    Public Property SMALL_UNIT() As String
        Get
            Return _SMALL_UNIT
        End Get
        Set(ByVal value As String)
            _SMALL_UNIT = value
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
    Private _LONG_APPDATE As String
    Public Property LONG_APPDATE() As String
        Get
            Return _LONG_APPDATE
        End Get
        Set(ByVal value As String)
            _LONG_APPDATE = value
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
    Private _LONG_RCVDATE As String
    Public Property LONG_RCVDATE() As String
        Get
            Return _LONG_RCVDATE
        End Get
        Set(ByVal value As String)
            _LONG_RCVDATE = value
        End Set
    End Property

    Private _QR_CODE As String
    Public Property QR_CODE() As String
        Get
            Return _QR_CODE
        End Get
        Set(ByVal value As String)
            _QR_CODE = value
        End Set
    End Property
#End Region

End Class
