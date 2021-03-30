Public Class CLASS_EDIT_DRRGT
    Inherits CLASS_CENTER
    Public DRRGT_EDIT_REQUESTs As New DRRGT_EDIT_REQUEST
    Public DRRGT_COLOR As New DRRGT_COLOR
    Public DRRGT_EDIT_REQUEST_COLOR As New DRRGT_EDIT_REQUEST_COLOR
    'เอาออก--------------------------
    'Public DRRGT_EDIT_REQUEST_CAS As New DRRGT_EDIT_REQUEST_CA
    'Public DRRGT_DETAIL_CAS As New DRRGT_DETAIL_CA
    '--------------------------------
    Public DRRGT_PACKAGE_DETAIL As New DRRGT_PACKAGE_DETAIL

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
    Private _RGTNO_FORMAT As String
    Public Property RGTNO_FORMAT() As String
        Get
            Return _RGTNO_FORMAT
        End Get
        Set(ByVal value As String)
            _RGTNO_FORMAT = value
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
    Private _APP_TYPE1 As String
    Public Property APP_TYPE1() As String
        Get
            Return _APP_TYPE1
        End Get
        Set(ByVal value As String)
            _APP_TYPE1 = value
        End Set
    End Property
    Private _APP_TYPE2 As String
    Public Property APP_TYPE2() As String
        Get
            Return _APP_TYPE2
        End Get
        Set(ByVal value As String)
            _APP_TYPE2 = value
        End Set
    End Property
    Private _APP_TYPE2_PURPOSE As String
    Public Property APP_TYPE2_PURPOSE() As String
        Get
            Return _APP_TYPE2_PURPOSE
        End Get
        Set(ByVal value As String)
            _APP_TYPE2_PURPOSE = value
        End Set
    End Property
    Private _APP_TYPE3 As String
    Public Property APP_TYPE3() As String
        Get
            Return _APP_TYPE3
        End Get
        Set(ByVal value As String)
            _APP_TYPE3 = value
        End Set
    End Property
    Private _APP_TYPE3_PURPOSE As String
    Public Property APP_TYPE3_PURPOSE() As String
        Get
            Return _APP_TYPE3_PURPOSE
        End Get
        Set(ByVal value As String)
            _APP_TYPE3_PURPOSE = value
        End Set
    End Property
    '
    Private _LCNTPCD_GROUP As String
    Public Property LCNTPCD_GROUP() As String
        Get
            Return _LCNTPCD_GROUP
        End Get
        Set(ByVal value As String)
            _LCNTPCD_GROUP = value
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
    Private _OLD_NAME_TH As String
    Public Property OLD_NAME_TH() As String
        Get
            Return _OLD_NAME_TH
        End Get
        Set(ByVal value As String)
            _OLD_NAME_TH = value
        End Set
    End Property
    Private _OLD_NAME_EN As String
    Public Property OLD_NAME_EN() As String
        Get
            Return _OLD_NAME_EN
        End Get
        Set(ByVal value As String)
            _OLD_NAME_EN = value
        End Set
    End Property

    Private _UNIT_NAME As String
    Public Property UNIT_NAME() As String
        Get
            Return _UNIT_NAME
        End Get
        Set(ByVal value As String)
            _UNIT_NAME = value
        End Set
    End Property
    Private _rcvdate As String
    Public Property rcvdate() As String
        Get
            Return _rcvdate
        End Get
        Set(ByVal value As String)
            _rcvdate = value
        End Set
    End Property

    Private _PHR_IDENTIFY As String
    Public Property PHR_IDENTIFY() As String
        Get
            Return _PHR_IDENTIFY
        End Get
        Set(ByVal value As String)
            _PHR_IDENTIFY = value
        End Set
    End Property
    Private _PHR_NAME As String
    Public Property PHR_NAME() As String
        Get
            Return _PHR_NAME
        End Get
        Set(ByVal value As String)
            _PHR_NAME = value
        End Set
    End Property
#End Region
    Private _DRRGT_EDIT_REQUEST_COLORs As New List(Of DRRGT_EDIT_REQUEST_COLOR)
    Public Property DRRGT_EDIT_REQUEST_COLORs As List(Of DRRGT_EDIT_REQUEST_COLOR)
        Get
            Return _DRRGT_EDIT_REQUEST_COLORs
        End Get
        Set(ByVal Value As List(Of DRRGT_EDIT_REQUEST_COLOR))
            _DRRGT_EDIT_REQUEST_COLORs = Value
        End Set
    End Property
    Private _DRRGT_COLORs As New List(Of DRRGT_COLOR)
    Public Property DRRGT_COLORs As List(Of DRRGT_COLOR)
        Get
            Return _DRRGT_COLORs
        End Get
        Set(ByVal Value As List(Of DRRGT_COLOR))
            _DRRGT_COLORs = Value
        End Set
    End Property
    'เอาออก--------------------------
    'Private _DRRGT_DETAIL_CASes As New List(Of DRRGT_DETAIL_CA)
    'Public Property DRRGT_DETAIL_CASes As List(Of DRRGT_DETAIL_CA)
    '    Get
    '        Return _DRRGT_DETAIL_CASes
    '    End Get
    '    Set(ByVal Value As List(Of DRRGT_DETAIL_CA))
    '        _DRRGT_DETAIL_CASes = Value
    '    End Set
    'End Property

    'Private _DRRGT_EDIT_REQUEST_CASes As New List(Of DRRGT_EDIT_REQUEST_CA)
    'Public Property DRRGT_EDIT_REQUEST_CASes As List(Of DRRGT_EDIT_REQUEST_CA)
    '    Get
    '        Return _DRRGT_EDIT_REQUEST_CASes
    '    End Get
    '    Set(ByVal Value As List(Of DRRGT_EDIT_REQUEST_CA))
    '        _DRRGT_EDIT_REQUEST_CASes = Value
    '    End Set
    'End Property
    '-----------------
    'cls_
    Private _DRRGT_PACKAGE_DETAILs As New List(Of DRRGT_PACKAGE_DETAIL)
    Public Property DRRGT_PACKAGE_DETAILs As List(Of DRRGT_PACKAGE_DETAIL)
        Get
            Return _DRRGT_PACKAGE_DETAILs
        End Get
        Set(ByVal Value As List(Of DRRGT_PACKAGE_DETAIL))
            _DRRGT_PACKAGE_DETAILs = Value
        End Set
    End Property
    Private _DRRGT_EDIT_REQUEST_PACKAGE_DETAILs As New List(Of DRRGT_EDIT_REQUEST_PACKAGE_DETAIL)
    Public Property DRRGT_EDIT_REQUEST_PACKAGE_DETAILs As List(Of DRRGT_EDIT_REQUEST_PACKAGE_DETAIL)
        Get
            Return _DRRGT_EDIT_REQUEST_PACKAGE_DETAILs
        End Get
        Set(ByVal Value As List(Of DRRGT_EDIT_REQUEST_PACKAGE_DETAIL))
            _DRRGT_EDIT_REQUEST_PACKAGE_DETAILs = Value
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

    Private _STAFF_IDEN_RECEIVE As String
    Public Property STAFF_IDEN_RECEIVE() As String
        Get
            Return _STAFF_IDEN_RECEIVE
        End Get
        Set(ByVal value As String)
            _STAFF_IDEN_RECEIVE = value
        End Set
    End Property

    Private _RCV_DATE_FORMAT As String
    Public Property RCV_DATE_FORMAT() As String
        Get
            Return _RCV_DATE_FORMAT
        End Get
        Set(ByVal value As String)
            _RCV_DATE_FORMAT = value
        End Set
    End Property

    Private _WRITE_DATE_FORMAT As String
    Public Property WRITE_DATE_FORMAT() As String
        Get
            Return _WRITE_DATE_FORMAT
        End Get
        Set(ByVal value As String)
            _WRITE_DATE_FORMAT = value
        End Set
    End Property
End Class
