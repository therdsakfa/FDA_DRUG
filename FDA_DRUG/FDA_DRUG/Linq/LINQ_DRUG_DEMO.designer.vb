﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="LGT_DRUG_DEMO")>  _
Partial Public Class LINQ_DRUG_DEMODataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertXML_NAME_TEST(instance As XML_NAME_TEST)
    End Sub
  Partial Private Sub UpdateXML_NAME_TEST(instance As XML_NAME_TEST)
    End Sub
  Partial Private Sub DeleteXML_NAME_TEST(instance As XML_NAME_TEST)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("LGT_DRUGDEMOConnectionString").ConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property XML_NAME_TESTs() As System.Data.Linq.Table(Of XML_NAME_TEST)
		Get
			Return Me.GetTable(Of XML_NAME_TEST)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.XML_NAME_TEST")>  _
Partial Public Class XML_NAME_TEST
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _IDA As Integer
	
	Private _Newcode As String
	
	Private _PATH As String
	
	Private _XML_NAME As String
	
	Private _STATUS_ID As System.Nullable(Of Integer)
	
	Private _STATUS_NAME As String
	
	Private _CITIZEN_UPLOAD As String
	
	Private _CITIZEN_UPDATE As String
	
	Private _CREATE_DATE As System.Nullable(Of Date)
	
	Private _UPDATE_DATE As System.Nullable(Of Date)
	
	Private _PROCESS_ID As System.Nullable(Of Integer)
	
	Private _RCVNO As System.Nullable(Of Integer)
	
	Private _RCVDATE As System.Nullable(Of Date)
	
	Private _REGISTER As String
	
	Private _TR_ID As String
	
	Private _DESCRIPTION As String
	
	Private _TR_ID_DRRGT As String
	
	Private _appdate As System.Nullable(Of Date)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnIDAChanging(value As Integer)
    End Sub
    Partial Private Sub OnIDAChanged()
    End Sub
    Partial Private Sub OnNewcodeChanging(value As String)
    End Sub
    Partial Private Sub OnNewcodeChanged()
    End Sub
    Partial Private Sub OnPATHChanging(value As String)
    End Sub
    Partial Private Sub OnPATHChanged()
    End Sub
    Partial Private Sub OnXML_NAMEChanging(value As String)
    End Sub
    Partial Private Sub OnXML_NAMEChanged()
    End Sub
    Partial Private Sub OnSTATUS_IDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnSTATUS_IDChanged()
    End Sub
    Partial Private Sub OnSTATUS_NAMEChanging(value As String)
    End Sub
    Partial Private Sub OnSTATUS_NAMEChanged()
    End Sub
    Partial Private Sub OnCITIZEN_UPLOADChanging(value As String)
    End Sub
    Partial Private Sub OnCITIZEN_UPLOADChanged()
    End Sub
    Partial Private Sub OnCITIZEN_UPDATEChanging(value As String)
    End Sub
    Partial Private Sub OnCITIZEN_UPDATEChanged()
    End Sub
    Partial Private Sub OnCREATE_DATEChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnCREATE_DATEChanged()
    End Sub
    Partial Private Sub OnUPDATE_DATEChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnUPDATE_DATEChanged()
    End Sub
    Partial Private Sub OnPROCESS_IDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnPROCESS_IDChanged()
    End Sub
    Partial Private Sub OnRCVNOChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnRCVNOChanged()
    End Sub
    Partial Private Sub OnRCVDATEChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnRCVDATEChanged()
    End Sub
    Partial Private Sub OnREGISTERChanging(value As String)
    End Sub
    Partial Private Sub OnREGISTERChanged()
    End Sub
    Partial Private Sub OnTR_IDChanging(value As String)
    End Sub
    Partial Private Sub OnTR_IDChanged()
    End Sub
    Partial Private Sub OnDESCRIPTIONChanging(value As String)
    End Sub
    Partial Private Sub OnDESCRIPTIONChanged()
    End Sub
    Partial Private Sub OnTR_ID_DRRGTChanging(value As String)
    End Sub
    Partial Private Sub OnTR_ID_DRRGTChanged()
    End Sub
    Partial Private Sub OnappdateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnappdateChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDA", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property IDA() As Integer
		Get
			Return Me._IDA
		End Get
		Set
			If ((Me._IDA = value)  _
						= false) Then
				Me.OnIDAChanging(value)
				Me.SendPropertyChanging
				Me._IDA = value
				Me.SendPropertyChanged("IDA")
				Me.OnIDAChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Newcode", DbType:="NVarChar(MAX)")>  _
	Public Property Newcode() As String
		Get
			Return Me._Newcode
		End Get
		Set
			If (String.Equals(Me._Newcode, value) = false) Then
				Me.OnNewcodeChanging(value)
				Me.SendPropertyChanging
				Me._Newcode = value
				Me.SendPropertyChanged("Newcode")
				Me.OnNewcodeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PATH", DbType:="NVarChar(MAX)")>  _
	Public Property PATH() As String
		Get
			Return Me._PATH
		End Get
		Set
			If (String.Equals(Me._PATH, value) = false) Then
				Me.OnPATHChanging(value)
				Me.SendPropertyChanging
				Me._PATH = value
				Me.SendPropertyChanged("PATH")
				Me.OnPATHChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_XML_NAME", DbType:="NVarChar(MAX)")>  _
	Public Property XML_NAME() As String
		Get
			Return Me._XML_NAME
		End Get
		Set
			If (String.Equals(Me._XML_NAME, value) = false) Then
				Me.OnXML_NAMEChanging(value)
				Me.SendPropertyChanging
				Me._XML_NAME = value
				Me.SendPropertyChanged("XML_NAME")
				Me.OnXML_NAMEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_STATUS_ID", DbType:="Int")>  _
	Public Property STATUS_ID() As System.Nullable(Of Integer)
		Get
			Return Me._STATUS_ID
		End Get
		Set
			If (Me._STATUS_ID.Equals(value) = false) Then
				Me.OnSTATUS_IDChanging(value)
				Me.SendPropertyChanging
				Me._STATUS_ID = value
				Me.SendPropertyChanged("STATUS_ID")
				Me.OnSTATUS_IDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_STATUS_NAME", DbType:="NVarChar(50)")>  _
	Public Property STATUS_NAME() As String
		Get
			Return Me._STATUS_NAME
		End Get
		Set
			If (String.Equals(Me._STATUS_NAME, value) = false) Then
				Me.OnSTATUS_NAMEChanging(value)
				Me.SendPropertyChanging
				Me._STATUS_NAME = value
				Me.SendPropertyChanged("STATUS_NAME")
				Me.OnSTATUS_NAMEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CITIZEN_UPLOAD", DbType:="NVarChar(50)")>  _
	Public Property CITIZEN_UPLOAD() As String
		Get
			Return Me._CITIZEN_UPLOAD
		End Get
		Set
			If (String.Equals(Me._CITIZEN_UPLOAD, value) = false) Then
				Me.OnCITIZEN_UPLOADChanging(value)
				Me.SendPropertyChanging
				Me._CITIZEN_UPLOAD = value
				Me.SendPropertyChanged("CITIZEN_UPLOAD")
				Me.OnCITIZEN_UPLOADChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CITIZEN_UPDATE", DbType:="NVarChar(50)")>  _
	Public Property CITIZEN_UPDATE() As String
		Get
			Return Me._CITIZEN_UPDATE
		End Get
		Set
			If (String.Equals(Me._CITIZEN_UPDATE, value) = false) Then
				Me.OnCITIZEN_UPDATEChanging(value)
				Me.SendPropertyChanging
				Me._CITIZEN_UPDATE = value
				Me.SendPropertyChanged("CITIZEN_UPDATE")
				Me.OnCITIZEN_UPDATEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CREATE_DATE", DbType:="DateTime")>  _
	Public Property CREATE_DATE() As System.Nullable(Of Date)
		Get
			Return Me._CREATE_DATE
		End Get
		Set
			If (Me._CREATE_DATE.Equals(value) = false) Then
				Me.OnCREATE_DATEChanging(value)
				Me.SendPropertyChanging
				Me._CREATE_DATE = value
				Me.SendPropertyChanged("CREATE_DATE")
				Me.OnCREATE_DATEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UPDATE_DATE", DbType:="DateTime")>  _
	Public Property UPDATE_DATE() As System.Nullable(Of Date)
		Get
			Return Me._UPDATE_DATE
		End Get
		Set
			If (Me._UPDATE_DATE.Equals(value) = false) Then
				Me.OnUPDATE_DATEChanging(value)
				Me.SendPropertyChanging
				Me._UPDATE_DATE = value
				Me.SendPropertyChanged("UPDATE_DATE")
				Me.OnUPDATE_DATEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PROCESS_ID", DbType:="Int")>  _
	Public Property PROCESS_ID() As System.Nullable(Of Integer)
		Get
			Return Me._PROCESS_ID
		End Get
		Set
			If (Me._PROCESS_ID.Equals(value) = false) Then
				Me.OnPROCESS_IDChanging(value)
				Me.SendPropertyChanging
				Me._PROCESS_ID = value
				Me.SendPropertyChanged("PROCESS_ID")
				Me.OnPROCESS_IDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_RCVNO", DbType:="Int")>  _
	Public Property RCVNO() As System.Nullable(Of Integer)
		Get
			Return Me._RCVNO
		End Get
		Set
			If (Me._RCVNO.Equals(value) = false) Then
				Me.OnRCVNOChanging(value)
				Me.SendPropertyChanging
				Me._RCVNO = value
				Me.SendPropertyChanged("RCVNO")
				Me.OnRCVNOChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_RCVDATE", DbType:="DateTime")>  _
	Public Property RCVDATE() As System.Nullable(Of Date)
		Get
			Return Me._RCVDATE
		End Get
		Set
			If (Me._RCVDATE.Equals(value) = false) Then
				Me.OnRCVDATEChanging(value)
				Me.SendPropertyChanging
				Me._RCVDATE = value
				Me.SendPropertyChanged("RCVDATE")
				Me.OnRCVDATEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_REGISTER", DbType:="NVarChar(50)")>  _
	Public Property REGISTER() As String
		Get
			Return Me._REGISTER
		End Get
		Set
			If (String.Equals(Me._REGISTER, value) = false) Then
				Me.OnREGISTERChanging(value)
				Me.SendPropertyChanging
				Me._REGISTER = value
				Me.SendPropertyChanged("REGISTER")
				Me.OnREGISTERChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TR_ID", DbType:="NVarChar(MAX)")>  _
	Public Property TR_ID() As String
		Get
			Return Me._TR_ID
		End Get
		Set
			If (String.Equals(Me._TR_ID, value) = false) Then
				Me.OnTR_IDChanging(value)
				Me.SendPropertyChanging
				Me._TR_ID = value
				Me.SendPropertyChanged("TR_ID")
				Me.OnTR_IDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DESCRIPTION", DbType:="NVarChar(MAX)")>  _
	Public Property DESCRIPTION() As String
		Get
			Return Me._DESCRIPTION
		End Get
		Set
			If (String.Equals(Me._DESCRIPTION, value) = false) Then
				Me.OnDESCRIPTIONChanging(value)
				Me.SendPropertyChanging
				Me._DESCRIPTION = value
				Me.SendPropertyChanged("DESCRIPTION")
				Me.OnDESCRIPTIONChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TR_ID_DRRGT", DbType:="NVarChar(MAX)")>  _
	Public Property TR_ID_DRRGT() As String
		Get
			Return Me._TR_ID_DRRGT
		End Get
		Set
			If (String.Equals(Me._TR_ID_DRRGT, value) = false) Then
				Me.OnTR_ID_DRRGTChanging(value)
				Me.SendPropertyChanging
				Me._TR_ID_DRRGT = value
				Me.SendPropertyChanged("TR_ID_DRRGT")
				Me.OnTR_ID_DRRGTChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_appdate", DbType:="DateTime")>  _
	Public Property appdate() As System.Nullable(Of Date)
		Get
			Return Me._appdate
		End Get
		Set
			If (Me._appdate.Equals(value) = false) Then
				Me.OnappdateChanging(value)
				Me.SendPropertyChanging
				Me._appdate = value
				Me.SendPropertyChanged("appdate")
				Me.OnappdateChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class
