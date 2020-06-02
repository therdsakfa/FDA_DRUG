Public Class LGT_ANIMAL_DRUGS_TO
    Private _XML_DRUG_ANIMAL As New XML_DRUG_ANIMAL
    Public Property XML_DRUG_ANIMAL() As XML_DRUG_ANIMAL
        Get
            Return _XML_DRUG_ANIMAL
        End Get
        Set(ByVal value As XML_DRUG_ANIMAL)
            _XML_DRUG_ANIMAL = value
        End Set
    End Property
    Private _LGT_ANIMAL_CONSUME_DRUGS_TO As New List(Of LGT_ANIMAL_CONSUME_DRUGS_TO)
    Public Property LGT_ANIMAL_CONSUME_DRUGS_TO() As List(Of LGT_ANIMAL_CONSUME_DRUGS_TO)
        Get
            Return _LGT_ANIMAL_CONSUME_DRUGS_TO
        End Get
        Set(ByVal value As List(Of LGT_ANIMAL_CONSUME_DRUGS_TO))
            _LGT_ANIMAL_CONSUME_DRUGS_TO = value
        End Set
    End Property

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
