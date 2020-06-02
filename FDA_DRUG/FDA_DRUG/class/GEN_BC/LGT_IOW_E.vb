Public Class LGT_IOW_E
    Private _XML_SEARCH_PRODUCT_GROUP As New XML_SEARCH_PRODUCT_GROUP_ESUB
    Public Property XML_SEARCH_DRUG_DR() As XML_SEARCH_PRODUCT_GROUP_ESUB
        Get
            Return _XML_SEARCH_PRODUCT_GROUP
        End Get
        Set(ByVal value As XML_SEARCH_PRODUCT_GROUP_ESUB)
            _XML_SEARCH_PRODUCT_GROUP = value
        End Set
    End Property

    Private _LGT_XML_STOWAGR_TO As New List(Of LGT_XML_STOWAGR_TO)
    Public Property LGT_XML_STOWAGR_TO() As List(Of LGT_XML_STOWAGR_TO)
        Get
            Return _LGT_XML_STOWAGR_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_STOWAGR_TO))
            _LGT_XML_STOWAGR_TO = value
        End Set
    End Property

    Private _LGT_RECIPE_GROUP_TO As New List(Of LGT_RECIPE_GROUP_TO)
    Public Property LGT_RECIPE_GROUP_TO() As List(Of LGT_RECIPE_GROUP_TO)
        Get
            Return _LGT_RECIPE_GROUP_TO
        End Get
        Set(ByVal value As List(Of LGT_RECIPE_GROUP_TO))
            _LGT_RECIPE_GROUP_TO = value
        End Set
    End Property
    Private _LGT_ANIMAL_DRUGS_TO As New List(Of LGT_ANIMAL_DRUGS_TO)
    Public Property LGT_ANIMAL_DRUGS_TO() As List(Of LGT_ANIMAL_DRUGS_TO)
        Get
            Return _LGT_ANIMAL_DRUGS_TO
        End Get
        Set(ByVal value As List(Of LGT_ANIMAL_DRUGS_TO))
            _LGT_ANIMAL_DRUGS_TO = value
        End Set
    End Property

    Private _LGT_IOW_EQ As New LGT_IOW_EQ
    Public Property LGT_IOW_EQ() As LGT_IOW_EQ
        Get
            Return _LGT_IOW_EQ
        End Get
        Set(ByVal value As LGT_IOW_EQ)
            _LGT_IOW_EQ = value
        End Set
    End Property
    Private _LGT_XML_FRGN_ALL_TO As New List(Of LGT_XML_FRGN_ALL_TO)
    Public Property LGT_XML_FRGN_ALL_TO() As List(Of LGT_XML_FRGN_ALL_TO)
        Get
            Return _LGT_XML_FRGN_ALL_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_FRGN_ALL_TO))
            _LGT_XML_FRGN_ALL_TO = value
        End Set
    End Property
    Private _LGT_XML_DRUG_EXPORT As New List(Of LGT_XML_DRUG_EXPORT)
    Public Property LGT_XML_DRUG_EXPORT() As List(Of LGT_XML_DRUG_EXPORT)
        Get
            Return _LGT_XML_DRUG_EXPORT
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_EXPORT))
            _LGT_XML_DRUG_EXPORT = value
        End Set
    End Property
    Private _LGT_XML_DRUG_COLOR As New List(Of LGT_XML_DRUG_COLOR)
    Public Property LGT_XML_DRUG_COLOR() As List(Of LGT_XML_DRUG_COLOR)
        Get
            Return _LGT_XML_DRUG_COLOR
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_COLOR))
            _LGT_XML_DRUG_COLOR = value
        End Set
    End Property
    Private _LGT_XML_DRUG_AGENT As New List(Of LGT_XML_DRUG_AGENT)
    Public Property LGT_XML_DRUG_AGENT() As List(Of LGT_XML_DRUG_AGENT)
        Get
            Return _LGT_XML_DRUG_AGENT
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_AGENT))
            _LGT_XML_DRUG_AGENT = value
        End Set
    End Property
    Private _LGT_XML_DRUG_STORY_EDIT_HISTORY As New List(Of LGT_XML_DRUG_STORY_EDIT_HISTORY)
    Public Property LGT_XML_DRUG_STORY_EDIT_HISTORY() As List(Of LGT_XML_DRUG_STORY_EDIT_HISTORY)
        Get
            Return _LGT_XML_DRUG_STORY_EDIT_HISTORY
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_STORY_EDIT_HISTORY))
            _LGT_XML_DRUG_STORY_EDIT_HISTORY = value
        End Set
    End Property

    Private _LGT_XML_DRUG_CONDITION_TABEAN As New List(Of LGT_XML_DRUG_CONDITION_TABEAN)
    Public Property LGT_XML_DRUG_CONDITION_TABEAN() As List(Of LGT_XML_DRUG_CONDITION_TABEAN)
        Get
            Return _LGT_XML_DRUG_CONDITION_TABEAN
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_CONDITION_TABEAN))
            _LGT_XML_DRUG_CONDITION_TABEAN = value
        End Set
    End Property

    Private _LGT_XML_DRUG_DOC_PDF As New List(Of LGT_XML_DRUG_DOC_PDF)
    Public Property LGT_XML_DRUG_DOC_PDF() As List(Of LGT_XML_DRUG_DOC_PDF)
        Get
            Return _LGT_XML_DRUG_DOC_PDF
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_DOC_PDF))
            _LGT_XML_DRUG_DOC_PDF = value
        End Set
    End Property

    Private _LGT_XML_DRUG_SPC As New List(Of LGT_XML_DRUG_SPC)
    Public Property LGT_XML_DRUG_SPC() As List(Of LGT_XML_DRUG_SPC)
        Get
            Return _LGT_XML_DRUG_SPC
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_SPC))
            _LGT_XML_DRUG_SPC = value
        End Set
    End Property
    Private _LGT_XML_DRUG_DOC_PI As New List(Of LGT_XML_DRUG_DOC_PI)
    Public Property LGT_XML_DRUG_DOC_PI() As List(Of LGT_XML_DRUG_DOC_PI)
        Get
            Return _LGT_XML_DRUG_DOC_PI
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_DOC_PI))
            _LGT_XML_DRUG_DOC_PI = value
        End Set
    End Property
    Private _LGT_XML_DRUG_DOC_PIL As New List(Of LGT_XML_DRUG_DOC_PIL)
    Public Property LGT_XML_DRUG_DOC_PIL() As List(Of LGT_XML_DRUG_DOC_PIL)
        Get
            Return _LGT_XML_DRUG_DOC_PIL
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_DOC_PIL))
            _LGT_XML_DRUG_DOC_PIL = value
        End Set
    End Property




    Private _LGT_XML_DRUG_SOURCE_OF_RM As New List(Of LGT_XML_DRUG_SOURCE_OF_RM)
    Public Property LGT_XML_DRUG_SOURCE_OF_RM() As List(Of LGT_XML_DRUG_SOURCE_OF_RM)
        Get
            Return _LGT_XML_DRUG_SOURCE_OF_RM
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_SOURCE_OF_RM))
            _LGT_XML_DRUG_SOURCE_OF_RM = value
        End Set
    End Property
    Private _LGT_XML_DRUG_CODE As New List(Of LGT_XML_DRUG_CODE)
    Public Property LGT_XML_DRUG_CODE() As List(Of LGT_XML_DRUG_CODE)
        Get
            Return _LGT_XML_DRUG_CODE
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_CODE))
            _LGT_XML_DRUG_CODE = value
        End Set
    End Property
    Private _LGT_XML_DRUG_CONTAIN As New List(Of LGT_XML_DRUG_CONTAIN)
    Public Property LGT_XML_DRUG_CONTAIN() As List(Of LGT_XML_DRUG_CONTAIN)
        Get
            Return _LGT_XML_DRUG_CONTAIN
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_CONTAIN))
            _LGT_XML_DRUG_CONTAIN = value
        End Set
    End Property
    Private _LGT_XML_DRUG_CONTROL_ANALYZE As New List(Of LGT_XML_DRUG_CONTROL_ANALYZE)
    Public Property LGT_XML_DRUG_CONTROL_ANALYZE() As List(Of LGT_XML_DRUG_CONTROL_ANALYZE)
        Get
            Return _LGT_XML_DRUG_CONTROL_ANALYZE
        End Get
        Set(ByVal value As List(Of LGT_XML_DRUG_CONTROL_ANALYZE))
            _LGT_XML_DRUG_CONTROL_ANALYZE = value
        End Set
    End Property


End Class
