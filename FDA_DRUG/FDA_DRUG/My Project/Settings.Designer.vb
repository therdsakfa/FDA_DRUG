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


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://medicina.fda.moph.go.th/FDA_DRUG/SV_REQUEST_NO.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_REQUEST_NO_SV_REQUEST_NO() As String
            Get
                Return CType(Me("FDA_DRUG_WS_REQUEST_NO_SV_REQUEST_NO"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://medicina.fda.moph.go.th/WS_QR_CODE/WS_QR_CODE.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_QR_CODE_WS_QR_CODE() As String
            Get
                Return CType(Me("FDA_DRUG_WS_QR_CODE_WS_QR_CODE"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://164.115.28.107/WS_DRUG_UPDATE_LCN/WS_DRUG_LCN/WS_DRUG.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_DRUG_WS_DRUG() As String
            Get
                Return CType(Me("FDA_DRUG_WS_DRUG_WS_DRUG"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.137/TEST_FLATEN/WS_FLATTEN.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_FLATTEN_WS_FLATTEN() As String
            Get
                Return CType(Me("FDA_DRUG_WS_FLATTEN_WS_FLATTEN"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://164.115.28.108/WS_LGTDRUG/WS_LGTDRUG.ASMX")>  _
        Public ReadOnly Property FDA_DRUG_WS_LGTDRUG_WS_LGTDRUG() As String
            Get
                Return CType(Me("FDA_DRUG_WS_LGTDRUG_WS_LGTDRUG"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.108/WS_CENTER/WS_CENTER.ASMX")>  _
        Public ReadOnly Property FDA_DRUG_WS_CENTER_WS_CENTER() As String
            Get
                Return CType(Me("FDA_DRUG_WS_CENTER_WS_CENTER"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.108/WS_Taxno_TaxnoAuthorize/WS_Taxno_TaxnoAuthorize.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_Taxno_TaxnoAuthorize_WebService1() As String
            Get
                Return CType(Me("FDA_DRUG_WS_Taxno_TaxnoAuthorize_WebService1"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.108/WS_get_Profile_By_Identify/WS_Taxno_TaxnoAuthorize.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_PVNCD_WebService1() As String
            Get
                Return CType(Me("FDA_DRUG_WS_PVNCD_WebService1"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.133/SPECIAL_PAYMENT_TXC_BSN/WEBSERVICE/SV_CHECK_PAYMENT.asmx")>  _
        Public ReadOnly Property FDA_DRUG_SV_CHK_PAYMENT_SV_CHECK_PAYMENT() As String
            Get
                Return CType(Me("FDA_DRUG_SV_CHK_PAYMENT_SV_CHECK_PAYMENT"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://164.115.28.108/Mail/FDA_MAIL.asmx")>  _
        Public ReadOnly Property FDA_DRUG_FDA_MAIL_FDA_MAIL() As String
            Get
                Return CType(Me("FDA_DRUG_FDA_MAIL_FDA_MAIL"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.105/WS_BOOKING_DRUG/WS_UPDATE_BOOKING_DRUG.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_UPDATE_C_Service1() As String
            Get
                Return CType(Me("FDA_DRUG_WS_UPDATE_C_Service1"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.105/WS_BOOKING_DRUG_DEMO/WS_UPDATE_BOOKING_DRUG.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_UPDATE_C_DEMO_Service1() As String
            Get
                Return CType(Me("FDA_DRUG_WS_UPDATE_C_DEMO_Service1"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.108/WS_CITIZEN/WS_FDA_CITIZEN.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_FDA_CITIZEN_WS_FDA_CITIZEN() As String
            Get
                Return CType(Me("FDA_DRUG_WS_FDA_CITIZEN_WS_FDA_CITIZEN"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.108/WS_TRADER/WS_TRADER.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_TRADERS_WS_TRADER() As String
            Get
                Return CType(Me("FDA_DRUG_WS_TRADERS_WS_TRADER"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.105/WS_ERROR_CENTER/WEB_SERVICE/WS_ERROR_CENTER.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_ERROR_CENTERS_WS_ERROR_CENTER() As String
            Get
                Return CType(Me("FDA_DRUG_WS_ERROR_CENTERS_WS_ERROR_CENTER"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.65/WS_AUTHEN4/Authentication.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_AUTHENTICATION_Authentication() As String
            Get
                Return CType(Me("FDA_DRUG_WS_AUTHENTICATION_Authentication"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.104/WS_AUTHEN4/Authentication.asmx")>  _
        Public ReadOnly Property FDA_DRUG_AUTHEN_LOG_Authentication() As String
            Get
                Return CType(Me("FDA_DRUG_AUTHEN_LOG_Authentication"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.108/WS_DATE/Service1.svc")>  _
        Public ReadOnly Property FDA_DRUG_WS_GETDATE_WORKING_Service1() As String
            Get
                Return CType(Me("FDA_DRUG_WS_GETDATE_WORKING_Service1"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.133/SPECIAL_PAYMENT_TXC_BSN/WEBSERVICE/SV_UPDATE_PAYMENT.asmx")>  _
        Public ReadOnly Property FDA_DRUG_SV_UPDATE_PAYMENT_SV_UPDATE_PAYMENT() As String
            Get
                Return CType(Me("FDA_DRUG_SV_UPDATE_PAYMENT_SV_UPDATE_PAYMENT"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.66/FDA_BLOCKV2/WS_BLOCKCHAIN.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_BLOCKCHAIN_WS_BLOCKCHAIN() As String
            Get
                Return CType(Me("FDA_DRUG_WS_BLOCKCHAIN_WS_BLOCKCHAIN"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.104/WS_AUTHEN4/Authentication.asmx")>  _
        Public ReadOnly Property FDA_DRUG_AUTHENTICATION_104_Authentication() As String
            Get
                Return CType(Me("FDA_DRUG_AUTHENTICATION_104_Authentication"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.66/WS_AUTHEN4/Authentication.asmx")>  _
        Public ReadOnly Property FDA_DRUG_Authentication_66_Authentication() As String
            Get
                Return CType(Me("FDA_DRUG_Authentication_66_Authentication"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://10.111.28.107/WS_INSERT_XML_CPN/WS_INSERT_XML_CPN/WS_INSERT_XML_DRUG.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_CREATE_XML_WS_INSERT_XML_DRUG() As String
            Get
                Return CType(Me("FDA_DRUG_WS_CREATE_XML_WS_INSERT_XML_DRUG"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://164.115.28.107/WS_DRUG/WS_DRUG/WS_DRUG.asmx")>  _
        Public ReadOnly Property FDA_DRUG_WS_DRUG_LOG_DR_WS_DRUG() As String
            Get
                Return CType(Me("FDA_DRUG_WS_DRUG_LOG_DR_WS_DRUG"),String)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.FDA_DRUG.My.MySettings
            Get
                Return Global.FDA_DRUG.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
