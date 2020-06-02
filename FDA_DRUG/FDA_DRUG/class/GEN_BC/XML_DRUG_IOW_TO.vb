Public Class XML_DRUG_IOW_TO

    Private _XML_DRUG_IOW As New XML_DRUG_IOW
    Public Property XML_DRUG_IOW() As XML_DRUG_IOW
        Get
            Return _XML_DRUG_IOW
        End Get
        Set(ByVal value As XML_DRUG_IOW)
            _XML_DRUG_IOW = value
        End Set
    End Property
    Private _LGT_IOW_EQ_TO As New List(Of LGT_IOW_EQ_TO)
    Public Property LGT_IOW_EQ_TO() As List(Of LGT_IOW_EQ_TO)
        Get
            Return _LGT_IOW_EQ_TO
        End Get
        Set(ByVal value As List(Of LGT_IOW_EQ_TO))
            _LGT_IOW_EQ_TO = value
        End Set
    End Property



End Class
