Public Class LGT_IOW_EQ
    Private _XML_DRUG_IOW_TYPE As New List(Of XML_DRUG_IOW_TYPE)
    Public Property XML_DRUG_IOW_TYPE() As List(Of XML_DRUG_IOW_TYPE)
        Get
            Return _XML_DRUG_IOW_TYPE
        End Get
        Set(ByVal value As List(Of XML_DRUG_IOW_TYPE))
            _XML_DRUG_IOW_TYPE = value
        End Set
    End Property

End Class
