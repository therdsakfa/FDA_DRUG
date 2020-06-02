Public Class CLASS_CHEMICAL_REQUEST

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


    Public CHEMICAL_REQUESTs As New CHEMICAL_REQUEST


  
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
