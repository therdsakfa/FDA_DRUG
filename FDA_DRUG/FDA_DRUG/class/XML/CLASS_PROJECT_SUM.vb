Public Class CLASS_PROJECT_SUM
    Inherits CLASS_CENTER
    Public drsamp As New drsamp
    Public dalcns As New dalcn
    Public DRUG_PROJECT_SUMMARY As New DRUG_PROJECT_SUMMARY
    Public DRUG_PROJECT_RESEARCH_FACILITY As New DRUG_PROJECT_RESEARCH_FACILITY
    Public DRUG_PROJECT_DRUG_LIST As New DRUG_PROJECT_DRUG_LIST
    Public DRUG_PROJECT_CLINICAL_LABORATORY As New DRUG_PROJECT_CLINICAL_LABORATORY
    Public DRUG_PRODUCT_ID As New DRUG_PRODUCT_ID

#Region "SHOW"
    Private _DT_SHOW As New CLS_SHOW
    Public Property DT_SHOW() As CLS_SHOW
        Get
            Return _DT_SHOW
        End Get
        Set(ByVal value As CLS_SHOW)
            _DT_SHOW = value
        End Set
    End Property
#End Region

#Region "MASTER"
    Private _DT_MASTER As New CLS_MASTER
    Public Property DT_MASTER() As CLS_MASTER
        Get
            Return _DT_MASTER
        End Get
        Set(ByVal value As CLS_MASTER)
            _DT_MASTER = value
        End Set
    End Property
#End Region

#Region "DataBase"

#Region "DRUG_PRODUCT_ID"
    Private _DRUG_PRODUCT_ID As New List(Of DRUG_PRODUCT_ID)
    Public Property DRUG_PRODUCT_IDS As List(Of DRUG_PRODUCT_ID)
        Get
            Return _DRUG_PRODUCT_ID
        End Get
        Set(ByVal Value As List(Of DRUG_PRODUCT_ID))
            _DRUG_PRODUCT_ID = Value
        End Set
    End Property
#End Region

#Region "DRSAMP_PACKAGE_DETAIL"
    Private _DRSAMP_PACKAGE_DETAIL As New List(Of DRSAMP_PACKAGE_DETAIL)
    Public Property DRSAMP_PACKAGE_DETAILS As List(Of DRSAMP_PACKAGE_DETAIL)
        Get
            Return _DRSAMP_PACKAGE_DETAIL
        End Get
        Set(ByVal Value As List(Of DRSAMP_PACKAGE_DETAIL))
            _DRSAMP_PACKAGE_DETAIL = Value
        End Set
    End Property
#End Region
#Region "DRUG_PROJECT_SUMMARY"
    Private _DRUG_PROJECT_SUMMARY As New List(Of DRUG_PROJECT_SUMMARY)
    Public Property DRUG_PROJECT_SUMMARYS As List(Of DRUG_PROJECT_SUMMARY)
        Get
            Return _DRUG_PROJECT_SUMMARY
        End Get
        Set(ByVal value As List(Of DRUG_PROJECT_SUMMARY))
            _DRUG_PROJECT_SUMMARY = value
        End Set
    End Property
#End Region

#Region "DRUG_PROJECT_RESEARCH_FACILITY"
    Private _DRUG_PROJECT_RESEARCH_FACILITY As New List(Of DRUG_PROJECT_RESEARCH_FACILITY)
    Public Property DRUG_PROJECT_RESEARCH_FACILITYS As List(Of DRUG_PROJECT_RESEARCH_FACILITY)
        Get
            Return _DRUG_PROJECT_RESEARCH_FACILITY
        End Get
        Set(ByVal value As List(Of DRUG_PROJECT_RESEARCH_FACILITY))
            _DRUG_PROJECT_RESEARCH_FACILITY = value
        End Set
    End Property
#End Region

#Region "DRUG_PROJECT_DRUG_LIST"
    Private _DRUG_PROJECT_DRUG_LIST As New List(Of DRUG_PROJECT_DRUG_LIST)
    Public Property DRUG_PROJECT_DRUG_LISTS As List(Of DRUG_PROJECT_DRUG_LIST)
        Get
            Return _DRUG_PROJECT_DRUG_LIST
        End Get
        Set(ByVal value As List(Of DRUG_PROJECT_DRUG_LIST))
            _DRUG_PROJECT_DRUG_LIST = value
        End Set
    End Property
#End Region

#Region "DRUG_PROJECT_CLINICAL_LABORATORY"
    Private _DRUG_PROJECT_CLINICAL_LABORATORY As New List(Of DRUG_PROJECT_CLINICAL_LABORATORY)
    Public Property DRUG_PROJECT_CLINICAL_LABORATORYS As List(Of DRUG_PROJECT_CLINICAL_LABORATORY)
        Get
            Return _DRUG_PROJECT_CLINICAL_LABORATORY
        End Get
        Set(ByVal value As List(Of DRUG_PROJECT_CLINICAL_LABORATORY))
            _DRUG_PROJECT_CLINICAL_LABORATORY = value
        End Set
    End Property

#End Region

#End Region

    Private IMPORT_AMOUNT As String
    Public Property IMPORT_AMOUNTS() As String
        Get
            Return IMPORT_AMOUNT
        End Get
        Set(ByVal value As String)
            IMPORT_AMOUNT = value
        End Set
    End Property

    Private LCNNO_SHOW As String
    Public Property LCNNO_SHOWS() As String
        Get
            Return LCNNO_SHOW
        End Get
        Set(ByVal value As String)
            LCNNO_SHOW = value
        End Set
    End Property
End Class