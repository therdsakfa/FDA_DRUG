
Public Class CLASS_OTHER_XML
    Inherits CLASS_CENTER
    Public drsunits As New drsunit
#Region "drsunit"
    Private _drsunit As New List(Of drsunit)
    Public Property drsunit As List(Of drsunit)
        Get
            Return _drsunit
        End Get
        Set(ByVal Value As List(Of drsunit))
            _drsunit = Value
        End Set
    End Property
#End Region
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

End Class

