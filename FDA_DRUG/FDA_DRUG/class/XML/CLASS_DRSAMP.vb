Namespace XML_CENTER
    Public Class CLASS_DRSAMP
        Inherits CLASS_CENTER
        Public drsamp As New drsamp
        Public dalcns As New dalcn
        Public regis As New DRUG_REGISTRATION
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

#Region "drsamp"
        Private _drsamp As New List(Of drsamp)
        Public Property drsamps As List(Of drsamp)
            Get
                Return _drsamp
            End Get
            Set(ByVal Value As List(Of drsamp))
                _drsamp = Value
            End Set
        End Property
#End Region

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

#Region "DRUG_UNIT"
        Private _DRUG_UNIT As New List(Of DRUG_UNIT)
        Public Property DRUG_UNITS As List(Of DRUG_UNIT)
            Get
                Return _DRUG_UNIT
            End Get
            Set(ByVal Value As List(Of DRUG_UNIT))
                _DRUG_UNIT = Value
            End Set
        End Property
#End Region

#Region "dalcn"
        Private _dalcn As New List(Of dalcn)
        Public Property dalcn As List(Of dalcn)
            Get
                Return _dalcn
            End Get
            Set(ByVal Value As List(Of dalcn))
                _dalcn = Value
            End Set
        End Property
#End Region

#Region "sysprefix"
        Private _sysprefix As New List(Of sysprefix)
        Public Property sysprefixs As List(Of sysprefix)
            Get
                Return _sysprefix
            End Get
            Set(ByVal Value As List(Of sysprefix))
                _sysprefix = Value
            End Set
        End Property
#End Region

        '#Region "_DRUG_REGISTRATION_PACKAGE_DETAIL"
        '        Private _DRUG_REGISTRATION_PACKAGE_DETAIL As New List(Of DRUG_REGISTRATION_PACKAGE_DETAIL)
        '        Public Property DRUG_REGISTRATION_PACKAGE_DETAIL As List(Of DRUG_REGISTRATION_PACKAGE_DETAIL)
        '            Get
        '                Return DRUG_REGISTRATION_PACKAGE_DETAIL
        '            End Get
        '            Set(ByVal Value As List(Of DRUG_REGISTRATION_PACKAGE_DETAIL))
        '                DRUG_REGISTRATION_PACKAGE_DETAIL = Value
        '            End Set
        '        End Property
        '#End Region
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

        '#Region "MAS_UNIT_CONTAIN"
        '        Private _MAS_UNIT_CONTAIN As New List(Of MAS_UNIT_CONTAIN)
        '        Public Property MAS_UNIT_CONTAINS As List(Of MAS_UNIT_CONTAIN)
        '            Get
        '                Return _MAS_UNIT_CONTAIN
        '            End Get
        '            Set(ByVal Value As List(Of MAS_UNIT_CONTAIN))
        '                _MAS_UNIT_CONTAIN = Value
        '            End Set
        '        End Property
        '#End Region
#End Region
        Private _WRITE_DATE As String
        Public Property WRITE_DATE() As String
            Get
                Return _WRITE_DATE
            End Get
            Set(ByVal value As String)
                _WRITE_DATE = value
            End Set
        End Property
        Private IMPORT_AMOUNT As String
        Public Property IMPORT_AMOUNTS() As String
            Get
                Return IMPORT_AMOUNT
            End Get
            Set(ByVal value As String)
                IMPORT_AMOUNT = value
            End Set
        End Property
        Private _THANMS As String
        Public Property THANMS() As String
            Get
                Return _THANMS
            End Get
            Set(ByVal value As String)
                _THANMS = value
            End Set
        End Property
        Private _APP_STAFF As String
        Public Property APP_STAFF() As String
            Get
                Return _APP_STAFF
            End Get
            Set(ByVal value As String)
                _APP_STAFF = value
            End Set
        End Property
        Private _phr_fullname As String
        Public Property phr_fullname() As String
            Get
                Return _phr_fullname
            End Get
            Set(ByVal value As String)
                _phr_fullname = value
            End Set
        End Property
        Private _phr_nm As String
        Public Property phr_nm() As String
            Get
                Return _phr_nm
            End Get
            Set(ByVal value As String)
                _phr_nm = value
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
        Private _APPDATE As String
        Public Property APPDATE() As String
            Get
                Return _APPDATE
            End Get
            Set(ByVal value As String)
                _APPDATE = value
            End Set
        End Property
        Private _RCVDATE As String
        Public Property RCVDATE() As String
            Get
                Return _RCVDATE
            End Get
            Set(ByVal value As String)
                _RCVDATE = value
            End Set
        End Property
    End Class
    ' 


End Namespace
