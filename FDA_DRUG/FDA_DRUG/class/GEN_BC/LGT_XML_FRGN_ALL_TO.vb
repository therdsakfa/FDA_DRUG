Public Class LGT_XML_FRGN_ALL_TO
    Private _XML_DRUG_FRGN As New XML_DRUG_FRGN
    Public Property XML_DRUG_FRGN() As XML_DRUG_FRGN
        Get
            Return _XML_DRUG_FRGN
        End Get
        Set(ByVal value As XML_DRUG_FRGN)
            _XML_DRUG_FRGN = value
        End Set
    End Property
End Class
