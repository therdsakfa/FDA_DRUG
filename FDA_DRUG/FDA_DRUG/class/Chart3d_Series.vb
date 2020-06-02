Namespace Chart3D_Series
    Public Class Rootobject
        Public Property chart As New Chart
        Public Property categories() As New Category
        Public Property dataset() As New List(Of Chart_Dataset)
        Public Property data As New List(Of Datum)
    End Class

    Public Class Chart
        Public Property palette As String
        Public Property caption As String
        Public Property yaxisname As String
        Public Property showvalues As String
        Public Property numvdivlines As String
        Public Property divlinealpha As String
        Public Property drawanchors As String
        Public Property labelpadding As String
        Public Property yaxisvaluespadding As String
        Public Property useroundedges As String
        Public Property legendborderalpha As String
        Public Property showborder As String
        Public Property showlegend As String

    End Class

    Public Class Category
        Public Property category() As Category1
    End Class

    Public Class Category1
        Public Property label As String
    End Class

    Public Class Chart_Dataset
        Public Property data() As Datum
    End Class

    Public Class Datum
        Public Property value As String
        Public Property dashed As String
        Public Property seriesname As String
        Public Property color As String
        Public Property label As String
        Public Property link As String
    End Class
End Namespace