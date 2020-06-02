''' <summary>
''' class Import / Export XML CER
''' </summary>
''' <remarks></remarks>
Public Class CLASS_CER
    Inherits CLASS_CENTER
#Region "additional"
    Private _LCNNO_SHOW As String
    Public Property LCNNO_SHOW() As String
        Get
            Return _LCNNO_SHOW
        End Get
        Set(ByVal value As String)
            _LCNNO_SHOW = value
        End Set
    End Property

    Private _TYPE_IMPORT As String
    Public Property TYPE_IMPORT() As String
        Get
            Return _TYPE_IMPORT
        End Get
        Set(ByVal value As String)
            _TYPE_IMPORT = value
        End Set

    End Property
    Private _COUNTRY_GMP_NAME As String
    Public Property COUNTRY_GMP_NAME() As String
        Get
            Return _COUNTRY_GMP_NAME
        End Get
        Set(ByVal value As String)
            _COUNTRY_GMP_NAME = value
        End Set

    End Property
    Private _COUNTRY_OF_DEPARTMENT_NAME As String
    Public Property COUNTRY_OF_DEPARTMENT_NAME() As String
        Get
            Return _COUNTRY_OF_DEPARTMENT_NAME
        End Get
        Set(ByVal value As String)
            _COUNTRY_OF_DEPARTMENT_NAME = value
        End Set

    End Property

    Private _MANUFACTURE_COUNTRY_NAME As String
    Public Property MANUFACTURE_COUNTRY_NAME() As String
        Get
            Return _MANUFACTURE_COUNTRY_NAME
        End Get
        Set(ByVal value As String)
            _MANUFACTURE_COUNTRY_NAME = value
        End Set

    End Property
    Private _LAB_COUNTRY_NAME As String
    Public Property LAB_COUNTRY_NAME() As String
        Get
            Return _LAB_COUNTRY_NAME
        End Get
        Set(ByVal value As String)
            _LAB_COUNTRY_NAME = value
        End Set

    End Property
    '
    Private _BUYER_COUNTRY_NAME As String
    Public Property BUYER_COUNTRY_NAME() As String
        Get
            Return _BUYER_COUNTRY_NAME
        End Get
        Set(ByVal value As String)
            _BUYER_COUNTRY_NAME = value
        End Set

    End Property
    '
    Private _BUYER_STANDARD_NAME As String
    Public Property BUYER_STANDARD_NAME() As String
        Get
            Return _BUYER_STANDARD_NAME
        End Get
        Set(ByVal value As String)
            _BUYER_STANDARD_NAME = value
        End Set

    End Property
    '
    Private _DEPARTMENT_REGIST_CER_NAME1 As String
    Public Property DEPARTMENT_REGIST_CER_NAME1() As String
        Get
            Return _DEPARTMENT_REGIST_CER_NAME1
        End Get
        Set(ByVal value As String)
            _DEPARTMENT_REGIST_CER_NAME1 = value
        End Set

    End Property
    Private _DEPARTMENT_REGIST_CER_NAME2 As String
    Public Property DEPARTMENT_REGIST_CER_NAME2() As String
        Get
            Return _DEPARTMENT_REGIST_CER_NAME2
        End Get
        Set(ByVal value As String)
            _DEPARTMENT_REGIST_CER_NAME2 = value
        End Set

    End Property
    '
    
#End Region

#Region "DataBase"

    Public CERs As New CER


#Region "lgt_impcerref"
    Private _lgt_impcerref As New List(Of lgt_impcerref)
    Public Property lgt_impcerref As List(Of lgt_impcerref)
        Get
            Return _lgt_impcerref
        End Get
        Set(ByVal Value As List(Of lgt_impcerref))
            _lgt_impcerref = Value
        End Set
    End Property
#End Region

#Region "CER_FDTYPE"
    Private _CER_FDTYPE As New List(Of CER_DRTYPE)
    Public Property CER_FDTYPE As List(Of CER_DRTYPE)
        Get
            Return _CER_FDTYPE
        End Get
        Set(ByVal Value As List(Of CER_DRTYPE))
            _CER_FDTYPE = Value
        End Set
    End Property

#End Region

#Region "CER_REF"
    Private _CER_REF As New List(Of CER_REF)
    Public Property CER_REF As List(Of CER_REF)
        Get
            Return _CER_REF
        End Get
        Set(ByVal Value As List(Of CER_REF))
            _CER_REF = Value
        End Set
    End Property

#End Region

#Region "CER_DETAIL_CASCHEMICAL"
    Private _CER_DETAIL_CASCHEMICAL As New List(Of CER_DETAIL_CASCHEMICAL)
    Public Property CER_DETAIL_CASCHEMICALs As List(Of CER_DETAIL_CASCHEMICAL)
        Get
            Return _CER_DETAIL_CASCHEMICAL
        End Get
        Set(ByVal Value As List(Of CER_DETAIL_CASCHEMICAL))
            _CER_DETAIL_CASCHEMICAL = Value
        End Set
    End Property
#End Region

#Region "CER_DETAIL_MANUFACTURE"
    Private _CER_DETAIL_MANUFACTURE As New List(Of CER_DETAIL_MANUFACTURE)
    Public Property CER_DETAIL_MANUFACTUREs As List(Of CER_DETAIL_MANUFACTURE)
        Get
            Return _CER_DETAIL_MANUFACTURE
        End Get
        Set(ByVal Value As List(Of CER_DETAIL_MANUFACTURE))
            _CER_DETAIL_MANUFACTURE = Value
        End Set
    End Property
#End Region

#End Region

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

  

    Private _URL_CHEMICAL_SEARCH As String
    Public Property URL_CHEMICAL_SEARCH() As String
        Get
            Return _URL_CHEMICAL_SEARCH
        End Get
        Set(ByVal value As String)
            _URL_CHEMICAL_SEARCH = value
        End Set
    End Property
    'Private _country_name As String
    'Public Property country_name() As String
    '    Get
    '        Return _country_name
    '    End Get
    '    Set(ByVal value As String)
    '        _country_name = value
    '    End Set
    'End Property
    'Private _COUNTRY_OF_DEPARTMENT As String
    'Public Property COUNTRY_OF_DEPARTMENT() As String
    '    Get
    '        Return _COUNTRY_OF_DEPARTMENT
    '    End Get
    '    Set(ByVal value As String)
    '        _COUNTRY_OF_DEPARTMENT = value
    '    End Set
    'End Property
End Class
