Namespace XML_CENTER
    Public Class CLASS_DALCN_NCT_SUBSTITUTE
        Inherits CLASS_CENTER
        Public DALCN_NCT_SUBSTITUTEs As New DALCN_NCT_SUBSTITUTE
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

#Region "additional"

        Private _EXP_YEAR As String
        Public Property EXP_YEAR() As String
            Get
                Return _EXP_YEAR
            End Get
            Set(ByVal value As String)
                _EXP_YEAR = value
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
        '
        Private _RCVDATE_DISPLAY As String
        Public Property RCVDATE_DISPLAY() As String
            Get
                Return _RCVDATE_DISPLAY
            End Get
            Set(ByVal value As String)
                _RCVDATE_DISPLAY = value
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

        Private _CHK_VALUE As String
        Public Property CHK_VALUE() As String
            Get
                Return _CHK_VALUE
            End Get
            Set(ByVal value As String)
                _CHK_VALUE = value
            End Set
        End Property

        Private _phr_medical_type As String
        Public Property phr_medical_type() As String
            Get
                Return _phr_medical_type
            End Get
            Set(ByVal value As String)
                _phr_medical_type = value
            End Set
        End Property
        Private _BSN_IDENTIFY As String
        Public Property BSN_IDENTIFY() As String
            Get
                Return _BSN_IDENTIFY
            End Get
            Set(ByVal value As String)
                _BSN_IDENTIFY = value
            End Set
        End Property
        Private _COUNT_PHESAJ1 As String
        Public Property COUNT_PHESAJ1() As String
            Get
                Return _COUNT_PHESAJ1
            End Get
            Set(ByVal value As String)
                _COUNT_PHESAJ1 = value
            End Set
        End Property
        Private _COUNT_PHESAJ2 As String
        Public Property COUNT_PHESAJ2() As String
            Get
                Return _COUNT_PHESAJ2
            End Get
            Set(ByVal value As String)
                _COUNT_PHESAJ2 = value
            End Set
        End Property
        Private _COUNT_PHESAJ3 As String
        Public Property COUNT_PHESAJ3() As String
            Get
                Return _COUNT_PHESAJ3
            End Get
            Set(ByVal value As String)
                _COUNT_PHESAJ3 = value
            End Set
        End Property
        Private _ALLOW_NAME As String
        Public Property ALLOW_NAME() As String
            Get
                Return _ALLOW_NAME
            End Get
            Set(ByVal value As String)
                _ALLOW_NAME = value
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
        Private _EMAIL As String
        Public Property EMAIL() As String
            Get
                Return _EMAIL
            End Get
            Set(ByVal value As String)
                _EMAIL = value
            End Set
        End Property
        Private _HEAD_LCNNO_NCT As String
        Public Property HEAD_LCNNO_NCT() As String
            Get
                Return _HEAD_LCNNO_NCT
            End Get
            Set(ByVal value As String)
                _HEAD_LCNNO_NCT = value
            End Set
        End Property
        Private _CHILD_LCNNO_NCT As String
        Public Property CHILD_LCNNO_NCT() As String
            Get
                Return _CHILD_LCNNO_NCT
            End Get
            Set(ByVal value As String)
                _CHILD_LCNNO_NCT = value
            End Set
        End Property


        Private _syslctaddr_thaaddr As String
        Public Property syslctaddr_thaaddr() As String
            Get
                Return _syslctaddr_thaaddr
            End Get
            Set(ByVal value As String)
                _syslctaddr_thaaddr = value
            End Set
        End Property
        Private _syslctaddr_engaddr As String
        Public Property syslctaddr_engaddr() As String
            Get
                Return _syslctaddr_engaddr
            End Get
            Set(ByVal value As String)
                _syslctaddr_engaddr = value
            End Set
        End Property
        Private _syslctaddr_room As String
        Public Property syslctaddr_room() As String
            Get
                Return _syslctaddr_room
            End Get
            Set(ByVal value As String)
                _syslctaddr_room = value
            End Set
        End Property
        Private _syslctaddr_mu As String
        Public Property syslctaddr_mu() As String
            Get
                Return _syslctaddr_mu
            End Get
            Set(ByVal value As String)
                _syslctaddr_mu = value
            End Set
        End Property
        Private _syslctaddr_floor As String
        Public Property syslctaddr_floor() As String
            Get
                Return _syslctaddr_floor
            End Get
            Set(ByVal value As String)
                _syslctaddr_floor = value
            End Set
        End Property
        Private _syslctaddr_thasoi As String
        Public Property syslctaddr_thasoi() As String
            Get
                Return _syslctaddr_thasoi
            End Get
            Set(ByVal value As String)
                _syslctaddr_thasoi = value
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
        Private _CHK_SELL_TYPE As String
        Public Property CHK_SELL_TYPE() As String
            Get
                Return _CHK_SELL_TYPE
            End Get
            Set(ByVal value As String)
                _CHK_SELL_TYPE = value
            End Set
        End Property
#End Region
    End Class
End Namespace

