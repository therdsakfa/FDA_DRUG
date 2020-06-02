Public Class XML_DRUG_IOW_TYPE
    Private _XML_DRUG_IOW_TO As New List(Of XML_DRUG_IOW_TO)
    Public Property XML_DRUG_IOW_TO() As List(Of XML_DRUG_IOW_TO)
        Get
            Return _XML_DRUG_IOW_TO
        End Get
        Set(ByVal value As List(Of XML_DRUG_IOW_TO))
            _XML_DRUG_IOW_TO = value
        End Set
    End Property
End Class
