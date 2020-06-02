Public Class CLASS_CER_FOREIGN
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

    Private _BSN_THAIFULLNAME As String
    Public Property BSN_THAIFULLNAME() As String
        Get
            Return _BSN_THAIFULLNAME
        End Get
        Set(ByVal value As String)
            _BSN_THAIFULLNAME = value
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

#End Region

#Region "DataBase"

    Public CER_FOREIGNs As New CER_FOREIGN
    Public CER_FOREIGN_MANUFACTUREs As New CER_FOREIGN_MANUFACTURE


#Region "CER_FOREIGN"
    Private _CER_FOREIGN As New List(Of CER_FOREIGN)
    Public Property CER_FOREIGN As List(Of CER_FOREIGN)
        Get
            Return _CER_FOREIGN
        End Get
        Set(ByVal Value As List(Of CER_FOREIGN))
            _CER_FOREIGN = Value
        End Set
    End Property
#End Region
#Region "CER_FOREIGN_MANUFACTURE"
    Private _CER_FOREIGN_MANUFACTURE As New List(Of CER_FOREIGN_MANUFACTURE)
    Public Property CER_FOREIGN_MANUFACTURE As List(Of CER_FOREIGN_MANUFACTURE)
        Get
            Return _CER_FOREIGN_MANUFACTURE
        End Get
        Set(ByVal Value As List(Of CER_FOREIGN_MANUFACTURE))
            _CER_FOREIGN_MANUFACTURE = Value
        End Set
    End Property
#End Region
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
End Class
