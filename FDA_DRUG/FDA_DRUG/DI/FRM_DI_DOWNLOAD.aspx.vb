Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient

Public Class FRM_DI_DOWNLOAD
    Inherits System.Web.UI.Page
    Private _lcnsid As Integer
    Private _thanm As String
    Private _CITIEZEN_ID As String
    Private _CITIEZEN_ID_AUTHORIZE As String
    Private _fdtypecd As String
    Private _fdtypenm As String
    Private _lcnno As String
    Private _lcnsid_customer As String
    Sub RunSession()
        _CITIEZEN_ID = Session("CITIEZEN_ID").ToString()
        _CITIEZEN_ID_AUTHORIZE = Session("CITIEZEN_ID_AUTHORIZE").ToString()
        _lcnsid = Integer.Parse(Session("lcnsid").ToString())
        _thanm = Session("thanm").ToString()
        _lcnno = Session("lcnno").ToString()
        _lcnsid_customer = Integer.Parse(Session("lcnsid_customer").ToString())
    End Sub
    Sub RunSession2()
        _fdtypecd = Session("fdtypecd").ToString()
        _fdtypenm = Session("fdtypenm").ToString()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'RunSession()
        'If Not IsPostBack Then

        '    load_Gv1()
        '    lbl_lcnno.Text = _lcnno
        'End If
    End Sub


End Class