''' <summary>
''' class Import / Export XML ยาตัวอย่าง
''' </summary>
''' <remarks></remarks>
Public Class CLASS_DS
    Inherits CLASS_CENTER
    Public drsamps As New drsamp
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

#Region "drsampfmlno"
    Private _drsampfmlno As New List(Of drsampfmlno)
    Public Property drsampfmlnos() As List(Of drsampfmlno)
        Get
            Return _drsampfmlno
        End Get
        Set(ByVal value As List(Of drsampfmlno))
            _drsampfmlno = value
        End Set
    End Property
#End Region

#Region "DRSAMP_DETAIL_CAS"
    Private _DRSAMP_DETAIL_CAS As New List(Of DRSAMP_DETAIL_CA)
    Public Property DRSAMP_DETAIL_CAS() As List(Of DRSAMP_DETAIL_CA)
        Get
            Return _DRSAMP_DETAIL_CAS
        End Get
        Set(ByVal value As List(Of DRSAMP_DETAIL_CA))
            _DRSAMP_DETAIL_CAS = value
        End Set
    End Property
#End Region
#End Region





End Class
