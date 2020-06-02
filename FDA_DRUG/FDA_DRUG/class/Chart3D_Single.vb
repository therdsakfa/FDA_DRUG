Namespace Chart3D_Single
    Public Class Rootobject
        Public Property chart As Chart
        Public Property data As New List(Of Datum)
    End Class

    Public Class Chart
        Public Property caption As String
        Public Property yaxisname As String
        Public Property numberprefix As String
        Public Property bgcolor As String
        Public Property showalternatehgridcolor As String
        Public Property showvalues As String
        Public Property labeldisplay As String
        Public Property divlinecolor As String
        Public Property divlinealpha As String
        Public Property useroundedges As String
        Public Property canvasbgcolor As String
        Public Property canvasbasecolor As String
        Public Property showcanvasbg As String
        Public Property animation As String
        Public Property palettecolors As String
        Public Property showborder As String
    End Class

    Public Class Datum
        Public Property label As String
        Public Property value As String
    End Class
End Namespace
