Public Class XML_CONSIDER_REQUESTS
    Inherits CLASS_CENTER
    Public DRUG_CONSIDER_REQUESTs As New DRUG_CONSIDER_REQUEST
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

    Private _SHOW_CONREQ_APPOINTMENT_DATE As String
    Public Property SHOW_CONREQ_APPOINTMENT_DATE() As String
        Get
            Return _SHOW_CONREQ_APPOINTMENT_DATE
        End Get
        Set(ByVal value As String)
            _SHOW_CONREQ_APPOINTMENT_DATE = value
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

    Private _LCNNO_SHOW As String
    Public Property LCNNO_SHOW() As String
        Get
            Return _LCNNO_SHOW
        End Get
        Set(ByVal value As String)
            _LCNNO_SHOW = value
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

#End Region

End Class

