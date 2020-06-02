Public Class CLASS_PHARMACIST_CANCEL
    Inherits CLASS_CENTER
    Public DALCN_PHR_CANCELs As New DALCN_PHR_CANCEL
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

#Region "DALCN_PHR_CANCEL_DETAIL"
    Private _DALCN_PHR_CANCEL_DETAIL As New List(Of DALCN_PHR_CANCEL_DETAIL)
    Public Property DALCN_PHR_CANCEL_DETAIL As List(Of DALCN_PHR_CANCEL_DETAIL)
        Get
            Return _DALCN_PHR_CANCEL_DETAIL
        End Get
        Set(ByVal Value As List(Of DALCN_PHR_CANCEL_DETAIL))
            _DALCN_PHR_CANCEL_DETAIL = Value
        End Set
    End Property
#End Region

#End Region
End Class
