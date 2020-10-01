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


#End Region

End Class
