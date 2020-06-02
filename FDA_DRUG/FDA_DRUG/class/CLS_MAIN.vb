Public Class CLS_MAIN
    Private _DT1 As DataTable
    Public Property DT1() As DataTable
        Get
            Return _DT1
        End Get
        Set(ByVal value As DataTable)
            _DT1 = value
        End Set
    End Property

    Private _DT2 As DataTable
    Public Property DT2() As DataTable
        Get
            Return _DT2
        End Get
        Set(ByVal value As DataTable)
            _DT2 = value
        End Set
    End Property

End Class
