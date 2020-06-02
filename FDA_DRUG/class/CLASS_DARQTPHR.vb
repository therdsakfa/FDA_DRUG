Public Class CLASS_DARQTPHR

    Private _phrno As String
    Public Property phrno() As String
        Get
            Return _phrno
        End Get
        Set(ByVal value As String)
            _phrno = value
        End Set
    End Property

    Private _phrcd As Integer
    Public Property phrcd() As Integer
        Get
            Return _phrcd
        End Get
        Set(ByVal value As Integer)
            _phrcd = value
        End Set
    End Property


    Private _opentime As String
    Public Property opentime() As String
        Get
            Return _opentime
        End Get
        Set(ByVal value As String)
            _opentime = value
        End Set
    End Property

End Class
