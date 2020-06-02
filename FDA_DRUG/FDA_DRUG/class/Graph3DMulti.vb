Namespace Graph3DMultiple


    Public Class Rootobject
        Public Property chart As New Chart
        Public Property categories() As New List(Of Category)
        Public Property dataset() As New List(Of Dataset)
    End Class

    Public Class Chart
        Public Property caption As String
        Public Property yaxisname As String
        Public Property canvasbgcolor As String
        Public Property canvasbasecolor As String
        Public Property tooltipbgcolor As String
        Public Property tooltipborder As String
        Public Property divlinecolor As String
        Public Property showcolumnshadow As String
        Public Property divlineisdashed As String
        Public Property divlinedashlen As String
        Public Property divlinedashgap As String
        Public Property numberprefix As String
        Public Property numbersuffix As String
        Public Property showborder As String
        Public Property formatnumberscale As String

    End Class

    Public Class Category
        Public Property category() As New List(Of Category1)
    End Class

    Public Class Category1
        Public Property label As String
    End Class

    Public Class Dataset
        Public Property seriesname As String
        Public Property color As String
        Public Property data() As New List(Of Datum)
    End Class

    Public Class Datum
        Public Property value As String
        Public Property link As String
    End Class
End Namespace