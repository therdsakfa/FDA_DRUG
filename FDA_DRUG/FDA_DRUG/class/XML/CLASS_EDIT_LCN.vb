Namespace XML_CENTER
    Public Class CLASS_EDIT_LCN
        Inherits CLASS_CENTER
        Public EDT_HISTORIES As New EDT_HISTORY
#Region "EDT_HISTORY"
        Private _EDT_HISTORY As New List(Of EDT_HISTORY)
        Public Property EDT_HISTORY As List(Of EDT_HISTORY)
            Get
                Return _EDT_HISTORY
            End Get
            Set(ByVal Value As List(Of EDT_HISTORY))
                _EDT_HISTORY = Value
            End Set
        End Property
#End Region


    End Class
End Namespace


