''' <summary>
''' class Import / Export XML ทะเบียนตำรับยา
''' </summary>
''' <remarks></remarks>
Public Class CLASS_DR
    Inherits CLASS_CENTER
    Public drrgts As New drrgt
    Public drrqts As New drrqt '
    Public DRRGT_COLORs As New DRRGT_COLOR
    Public DRRGT_DETAIL_Cs As New DRRGT_DETAIL_CA
    Public DRRGT_PACKAGE_DETAILs As New DRRGT_PACKAGE_DETAIL
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


    '#Region "drpcksize"
    '    Private _drpcksize As New List(Of drpcksize)
    '    Public Property drpcksizes() As List(Of drpcksize)
    '        Get
    '            Return _drpcksize
    '        End Get
    '        Set(ByVal value As List(Of drpcksize))
    '            _drpcksize = value
    '        End Set
    '    End Property
    '#End Region

    '#Region "drusedrg"
    '    Private _drusedrg As New List(Of drusedrg)
    '    Public Property drusedrgs() As List(Of drusedrg)
    '        Get
    '            Return _drusedrg
    '        End Get
    '        Set(ByVal value As List(Of drusedrg))
    '            _drusedrg = value
    '        End Set
    '    End Property
    '#End Region


#Region "DRRGT_DETAIL_ROLE"
    Private _DRRGT_DETAIL_ROLE As New List(Of DRRGT_DETAIL_ROLE)
    Public Property DRRGT_DETAIL_ROLEs() As List(Of DRRGT_DETAIL_ROLE)
        Get
            Return _DRRGT_DETAIL_ROLE
        End Get
        Set(ByVal value As List(Of DRRGT_DETAIL_ROLE))
            _DRRGT_DETAIL_ROLE = value
        End Set
    End Property
#End Region

#Region "DRRGT_ATC_DETAIL"
    Private _DRRGT_ATC_DETAIL As New List(Of DRRGT_ATC_DETAIL)
    Public Property DRRGT_ATC_DETAIL() As List(Of DRRGT_ATC_DETAIL)
        Get
            Return _DRRGT_ATC_DETAIL
        End Get
        Set(ByVal value As List(Of DRRGT_ATC_DETAIL))
            _DRRGT_ATC_DETAIL = value
        End Set
    End Property
#End Region

#Region "DRRGT_DETAIL_CA"
    Private _DRRGT_DETAIL_CA As New List(Of DRRGT_DETAIL_CA)
    Public Property DRRGT_DETAIL_CA() As List(Of DRRGT_DETAIL_CA)
        Get
            Return _DRRGT_DETAIL_CA
        End Get
        Set(ByVal value As List(Of DRRGT_DETAIL_CA))
            _DRRGT_DETAIL_CA = value
        End Set
    End Property
#End Region
#Region "_DRRGT_PACKAGE_DETAIL"
    Private _DRRGT_PACKAGE_DETAIL As New List(Of DRRGT_PACKAGE_DETAIL)
    Public Property DRRGT_PACKAGE_DETAIL() As List(Of DRRGT_PACKAGE_DETAIL)
        Get
            Return _DRRGT_PACKAGE_DETAIL
        End Get
        Set(ByVal value As List(Of DRRGT_PACKAGE_DETAIL))
            _DRRGT_PACKAGE_DETAIL = value
        End Set
    End Property
#End Region


#Region "DRRGT_PRODUCER"
    Private _DRRGT_PRODUCER As New List(Of DRRGT_PRODUCER)
    Public Property DRRGT_PRODUCER() As List(Of DRRGT_PRODUCER)
        Get
            Return _DRRGT_PRODUCER
        End Get
        Set(ByVal value As List(Of DRRGT_PRODUCER))
            _DRRGT_PRODUCER = value
        End Set
    End Property
#End Region
#Region "DRRGT_PRODUCER_IN"
    Private _DRRGT_PRODUCER_IN As New List(Of DRRGT_PRODUCER_IN)
    Public Property DRRGT_PRODUCER_IN() As List(Of DRRGT_PRODUCER_IN)
        Get
            Return _DRRGT_PRODUCER_IN
        End Get
        Set(ByVal value As List(Of DRRGT_PRODUCER_IN))
            _DRRGT_PRODUCER_IN = value
        End Set
    End Property
#End Region


#Region "DRRGT_PROPERTy"
    Private _DRRGT_PROPERTy As New List(Of DRRGT_PROPERTy)
    Public Property DRRGT_PROPERTy() As List(Of DRRGT_PROPERTy)
        Get
            Return _DRRGT_PROPERTy
        End Get
        Set(ByVal value As List(Of DRRGT_PROPERTy))
            _DRRGT_PROPERTy = value
        End Set
    End Property
#End Region

#Region "DRRGT_PRODUCER_OTHER"
    Private _DRRGT_PRODUCER_OTHER As New List(Of DRRGT_PRODUCER_OTHER)
    Public Property DRRGT_PRODUCER_OTHER() As List(Of DRRGT_PRODUCER_OTHER)
        Get
            Return _DRRGT_PRODUCER_OTHER
        End Get
        Set(ByVal value As List(Of DRRGT_PRODUCER_OTHER))
            _DRRGT_PRODUCER_OTHER = value
        End Set
    End Property
#End Region

#Region "DRRQT_ATC_DETAIL"
    Private _DRRQT_ATC_DETAIL As New List(Of DRRQT_ATC_DETAIL)
    Public Property DRRQT_ATC_DETAIL() As List(Of DRRQT_ATC_DETAIL)
        Get
            Return _DRRQT_ATC_DETAIL
        End Get
        Set(ByVal value As List(Of DRRQT_ATC_DETAIL))
            _DRRQT_ATC_DETAIL = value
        End Set
    End Property
#End Region

#Region "DRRQT_DETAIL_CA"
    Private _DRRQT_DETAIL_CA As New List(Of DRRQT_DETAIL_CA)
    Public Property DRRQT_DETAIL_CA() As List(Of DRRQT_DETAIL_CA)
        Get
            Return _DRRQT_DETAIL_CA
        End Get
        Set(ByVal value As List(Of DRRQT_DETAIL_CA))
            _DRRQT_DETAIL_CA = value
        End Set
    End Property
#End Region

#Region "_DRRQT_PACKAGE_DETAIL"
    Private _DRRQT_PACKAGE_DETAIL As New List(Of DRRQT_PACKAGE_DETAIL)
    Public Property DRRQT_PACKAGE_DETAIL() As List(Of DRRQT_PACKAGE_DETAIL)
        Get
            Return _DRRQT_PACKAGE_DETAIL
        End Get
        Set(ByVal value As List(Of DRRQT_PACKAGE_DETAIL))
            _DRRQT_PACKAGE_DETAIL = value
        End Set
    End Property
#End Region
#Region "DRRQT_PRODUCER"
    Private _DRRQT_PRODUCER As New List(Of DRRQT_PRODUCER)
    Public Property DRRQT_PRODUCER() As List(Of DRRQT_PRODUCER)
        Get
            Return _DRRQT_PRODUCER
        End Get
        Set(ByVal value As List(Of DRRQT_PRODUCER))
            _DRRQT_PRODUCER = value
        End Set
    End Property
#End Region
#Region "DRRQT_PRODUCER_IN"
    Private _DRRQT_PRODUCER_IN As New List(Of DRRQT_PRODUCER_IN)
    Public Property DRRQT_PRODUCER_IN() As List(Of DRRQT_PRODUCER_IN)
        Get
            Return _DRRQT_PRODUCER_IN
        End Get
        Set(ByVal value As List(Of DRRQT_PRODUCER_IN))
            _DRRQT_PRODUCER_IN = value
        End Set
    End Property
#End Region
#Region "DRRGT_COLOR"
    Private _DRRGT_COLOR As List(Of DRRGT_COLOR)
    Public Property DRRGT_COLOR() As List(Of DRRGT_COLOR)
        Get
            Return _DRRGT_COLOR
        End Get
        Set(ByVal value As List(Of DRRGT_COLOR))
            _DRRGT_COLOR = value
        End Set
    End Property
#End Region


#Region "DRRQT_PROPERTy"
    Private _DRRQT_PROPERTy As New List(Of DRRQT_PROPERTy)
    Public Property DRRQT_PROPERTy() As List(Of DRRQT_PROPERTy)
        Get
            Return _DRRQT_PROPERTy
        End Get
        Set(ByVal value As List(Of DRRQT_PROPERTy))
            _DRRQT_PROPERTy = value
        End Set
    End Property
#End Region
#Region "DRRQT_PRODUCER_OTHER"
    Private _DRRQT_PRODUCER_OTHER As New List(Of DRRQT_PRODUCER_OTHER)
    Public Property DRRQT_PRODUCER_OTHER() As List(Of DRRQT_PRODUCER_OTHER)
        Get
            Return _DRRQT_PRODUCER_OTHER
        End Get
        Set(ByVal value As List(Of DRRQT_PRODUCER_OTHER))
            _DRRQT_PRODUCER_OTHER = value
        End Set
    End Property
#End Region
#Region "additional"
    Private _TABEAN_TYPE As String
    Public Property TABEAN_TYPE() As String
        Get
            Return _TABEAN_TYPE
        End Get
        Set(ByVal value As String)
            _TABEAN_TYPE = value
        End Set
    End Property
    Private _TABEAN_FORMAT As String
    Public Property TABEAN_FORMAT() As String
        Get
            Return _TABEAN_FORMAT
        End Get
        Set(ByVal value As String)
            _TABEAN_FORMAT = value
        End Set
    End Property
    Private _LCNNO_FORMAT As String
    Public Property LCNNO_FORMAT() As String
        Get
            Return _LCNNO_FORMAT
        End Get
        Set(ByVal value As String)
            _LCNNO_FORMAT = value
        End Set
    End Property

    Private _RCVNO_FORMAT As String
    Public Property RCVNO_FORMAT() As String
        Get
            Return _RCVNO_FORMAT
        End Get
        Set(ByVal value As String)
            _RCVNO_FORMAT = value
        End Set
    End Property

    Private _LCN_TYPE As String
    Public Property LCN_TYPE() As String
        Get
            Return _LCN_TYPE
        End Get
        Set(ByVal value As String)
            _LCN_TYPE = value
        End Set
    End Property

    Private _EXP_YEAR As String
    Public Property EXP_YEAR() As String
        Get
            Return _EXP_YEAR
        End Get
        Set(ByVal value As String)
            _EXP_YEAR = value
        End Set
    End Property

    Private _RCVDAY As String
    Public Property RCVDAY() As String
        Get
            Return _RCVDAY
        End Get
        Set(ByVal value As String)
            _RCVDAY = value
        End Set
    End Property
    Private _RCVMONTH As String
    Public Property RCVMONTH() As String
        Get
            Return _RCVMONTH
        End Get
        Set(ByVal value As String)
            _RCVMONTH = value
        End Set
    End Property

    Private _RCVYEAR As String
    Public Property RCVYEAR() As String
        Get
            Return _RCVYEAR
        End Get
        Set(ByVal value As String)
            _RCVYEAR = value
        End Set
    End Property
    Private _DRUG_NAME As String
    Public Property DRUG_NAME() As String
        Get
            Return _DRUG_NAME
        End Get
        Set(ByVal value As String)
            _DRUG_NAME = value
        End Set
    End Property
    Private _COUNTRY As String
    Public Property COUNTRY() As String
        Get
            Return _COUNTRY
        End Get
        Set(ByVal value As String)
            _COUNTRY = value
        End Set
    End Property

    Private _Dossage_form As String
    Public Property Dossage_form() As String
        Get
            Return _Dossage_form
        End Get
        Set(ByVal value As String)
            _Dossage_form = value
        End Set
    End Property
    Private _DRUG_PROPERTIES_AND_DETAIL As String
    Public Property DRUG_PROPERTIES_AND_DETAIL() As String
        Get
            Return _DRUG_PROPERTIES_AND_DETAIL
        End Get
        Set(ByVal value As String)
            _DRUG_PROPERTIES_AND_DETAIL = value
        End Set
    End Property
    Private _DRUG_PER_UNIT As String
    Public Property DRUG_PER_UNIT() As String
        Get
            Return _DRUG_PER_UNIT
        End Get
        Set(ByVal value As String)
            _DRUG_PER_UNIT = value
        End Set
    End Property
    Private _PACK_SIZE As String
    Public Property PACK_SIZE() As String
        Get
            Return _PACK_SIZE
        End Get
        Set(ByVal value As String)
            _PACK_SIZE = value
        End Set
    End Property
    '
    Private _DRUG_STRENGTH As String
    Public Property DRUG_STRENGTH() As String
        Get
            Return _DRUG_STRENGTH
        End Get
        Set(ByVal value As String)
            _DRUG_STRENGTH = value
        End Set
    End Property
    '
    Private _CHK_LCN_SUBTYPE1 As String
    Public Property CHK_LCN_SUBTYPE1() As String
        Get
            Return _CHK_LCN_SUBTYPE1
        End Get
        Set(ByVal value As String)
            _CHK_LCN_SUBTYPE1 = value
        End Set
    End Property
    Private _CHK_LCN_SUBTYPE2 As String
    Public Property CHK_LCN_SUBTYPE2() As String
        Get
            Return _CHK_LCN_SUBTYPE2
        End Get
        Set(ByVal value As String)
            _CHK_LCN_SUBTYPE2 = value
        End Set
    End Property
    Private _CHK_LCN_SUBTYPE3 As String
    Public Property CHK_LCN_SUBTYPE3() As String
        Get
            Return _CHK_LCN_SUBTYPE3
        End Get
        Set(ByVal value As String)
            _CHK_LCN_SUBTYPE3 = value
        End Set
    End Property
    '
    Private _TABEAN_TYPE1 As String
    Public Property TABEAN_TYPE1() As String
        Get
            Return _TABEAN_TYPE1
        End Get
        Set(ByVal value As String)
            _TABEAN_TYPE1 = value
        End Set
    End Property
    Private _TABEAN_TYPE2 As String
    Public Property TABEAN_TYPE2() As String
        Get
            Return _TABEAN_TYPE2
        End Get
        Set(ByVal value As String)
            _TABEAN_TYPE2 = value
        End Set
    End Property
    Private _TRANSFER As String
    Public Property TRANSFER() As String
        Get
            Return _TRANSFER
        End Get
        Set(ByVal value As String)
            _TRANSFER = value
        End Set
    End Property

    Private _SUBS_APP_DAY As String
    Public Property SUBS_APP_DAY() As String
        Get
            Return _SUBS_APP_DAY
        End Get
        Set(ByVal value As String)
            _SUBS_APP_DAY = value
        End Set
    End Property
    Private _SUBS_APP_MONTH As String
    Public Property SUBS_APP_MONTH() As String
        Get
            Return _SUBS_APP_MONTH
        End Get
        Set(ByVal value As String)
            _SUBS_APP_MONTH = value
        End Set
    End Property

    Private _SUBS_APP_YEAR As String
    Public Property SUBS_APP_YEAR() As String
        Get
            Return _SUBS_APP_YEAR
        End Get
        Set(ByVal value As String)
            _SUBS_APP_YEAR = value
        End Set
    End Property

    Private _FULL_SUBS_APPDATER As String
    Public Property FULL_SUBS_APPDATER() As String
        Get
            Return _FULL_SUBS_APPDATER
        End Get
        Set(ByVal value As String)
            _FULL_SUBS_APPDATER = value
        End Set
    End Property

    Private _STAFF_NAME1 As String
    Public Property STAFF_NAME1() As String
        Get
            Return _STAFF_NAME1
        End Get
        Set(ByVal value As String)
            _STAFF_NAME1 = value
        End Set
    End Property
    Private _STAFF_NAME2 As String
    Public Property STAFF_NAME2() As String
        Get
            Return _STAFF_NAME2
        End Get
        Set(ByVal value As String)
            _STAFF_NAME2 = value
        End Set
    End Property
    Private _POSITION_NAME1 As String
    Public Property POSITION_NAME1() As String
        Get
            Return _POSITION_NAME1
        End Get
        Set(ByVal value As String)
            _POSITION_NAME1 = value
        End Set
    End Property
    Private _POSITION_NAME2 As String
    Public Property POSITION_NAME2() As String
        Get
            Return _POSITION_NAME2
        End Get
        Set(ByVal value As String)
            _POSITION_NAME2 = value
        End Set
    End Property
    Private _DRUG_CLASS_NAME As String
    Public Property DRUG_CLASS_NAME() As String
        Get
            Return _DRUG_CLASS_NAME
        End Get
        Set(ByVal value As String)
            _DRUG_CLASS_NAME = value
        End Set
    End Property

    Private _EXPDAY As String
    Public Property EXPDAY() As String
        Get
            Return _EXPDAY
        End Get
        Set(ByVal value As String)
            _EXPDAY = value
        End Set
    End Property

    Private _EXPMONTH As String
    Public Property EXPMONTH() As String
        Get
            Return _EXPMONTH
        End Get
        Set(ByVal value As String)
            _EXPMONTH = value
        End Set
    End Property
    Private _EXPDATESHORT As String
    Public Property EXPDATESHORT() As String
        Get
            Return _EXPDATESHORT
        End Get
        Set(ByVal value As String)
            _EXPDATESHORT = value
        End Set
    End Property
    Private _QR_CODE As String
    Public Property QR_CODE() As String
        Get
            Return _QR_CODE
        End Get
        Set(ByVal value As String)
            _QR_CODE = value
        End Set
    End Property
    '
    Private _BSN_THAIFULLNAME As String
    Public Property BSN_THAIFULLNAME() As String
        Get
            Return _BSN_THAIFULLNAME
        End Get
        Set(ByVal value As String)
            _BSN_THAIFULLNAME = value
        End Set
    End Property
#End Region
#End Region
End Class
