Public Class LGT_RECIPE_GROUP_TO
    Private _XML_DRUG_RECIPE_GROUP As New XML_DRUG_RECIPE_GROUP 'New List(Of LGT_XML_FRGN_ALL_TO)
    Public Property XML_DRUG_RECIPE_GROUP() As XML_DRUG_RECIPE_GROUP
        Get
            Return _XML_DRUG_RECIPE_GROUP
        End Get
        Set(ByVal value As XML_DRUG_RECIPE_GROUP)
            _XML_DRUG_RECIPE_GROUP = value
        End Set
    End Property
    '
    'Private _XML_RECIPE_GROUPT As New XML_RECIPE_GROUPT
    'Public Property XML_RECIPE_GROUPT As XML_RECIPE_GROUPT
    '    Get
    '        Return _XML_RECIPE_GROUPT
    '    End Get
    '    Set(ByVal value As XML_RECIPE_GROUPT)
    '        _XML_RECIPE_GROUPT = value
    '    End Set
    'End Property
End Class
