Public Class LGT_ANIMAL_CONSUME_DRUGS_TO
    Private _XML_DRUG_ANIMAL_CONSUME As New XML_DRUG_ANIMAL_CONSUME
    Public Property XML_DRUG_ANIMAL_CONSUME() As XML_DRUG_ANIMAL_CONSUME
        Get
            Return _XML_DRUG_ANIMAL_CONSUME
        End Get
        Set(ByVal value As XML_DRUG_ANIMAL_CONSUME)
            _XML_DRUG_ANIMAL_CONSUME = value
        End Set
    End Property
End Class
