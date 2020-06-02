
'''<remarks/>
<System.SerializableAttribute(),
System.ComponentModel.DesignerCategoryAttribute("code"),
System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class CLASS_NORYORMOR5
    Private licenField As New CLASS_NORYORMOR5Licen

    Private pharmacyField As New CLASS_NORYORMOR5Pharmacy

    Private storgeField As New CLASS_NORYORMOR5Storge

    Private drugField As New CLASS_NORYORMOR5Drug

    Private mftField As New CLASS_NORYORMOR5Mft

    Private medicineField As New CLASS_NORYORMOR5Medicine

    Private antivirusField As New CLASS_NORYORMOR5Antivirus

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

    Private pageField As Object

    Private otherField As Object

    '''<remarks/>
    Public Property licen() As CLASS_NORYORMOR5Licen
        Get
            Return Me.licenField
        End Get
        Set
            Me.licenField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property pharmacy() As CLASS_NORYORMOR5Pharmacy
        Get
            Return Me.pharmacyField
        End Get
        Set
            Me.pharmacyField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property storge() As CLASS_NORYORMOR5Storge
        Get
            Return Me.storgeField
        End Get
        Set
            Me.storgeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property drug() As CLASS_NORYORMOR5Drug
        Get
            Return Me.drugField
        End Get
        Set
            Me.drugField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property mft() As CLASS_NORYORMOR5Mft
        Get
            Return Me.mftField
        End Get
        Set
            Me.mftField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property medicine() As CLASS_NORYORMOR5Medicine
        Get
            Return Me.medicineField
        End Get
        Set
            Me.medicineField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property antivirus() As CLASS_NORYORMOR5Antivirus
        Get
            Return Me.antivirusField
        End Get
        Set
            Me.antivirusField = Value
        End Set
    End Property


    '''<remarks/>
    Public Property page() As Object
        Get
            Return Me.pageField
        End Get
        Set
            Me.pageField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property other() As Object
        Get
            Return Me.otherField
        End Get
        Set
            Me.otherField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class CLASS_NORYORMOR5Licen

    Private prefixField As Object

    Private nameField As Object

    Private positionField As Object

    Private companyField As Object

    Private addrField As Object

    Private soiField As Object

    Private roadField As Object

    Private mooField As Object

    Private thmblnmField As Object

    Private amphrnmField As Object

    Private chngwtnmField As Object

    Private telField As Object

    Private faxField As Object

    Private amountField As Object

    '''<remarks/>
    Public Property prefix() As Object
        Get
            Return Me.prefixField
        End Get
        Set
            Me.prefixField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property name() As Object
        Get
            Return Me.nameField
        End Get
        Set
            Me.nameField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property position() As Object
        Get
            Return Me.positionField
        End Get
        Set
            Me.positionField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property company() As Object
        Get
            Return Me.companyField
        End Get
        Set
            Me.companyField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property addr() As Object
        Get
            Return Me.addrField
        End Get
        Set
            Me.addrField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property soi() As Object
        Get
            Return Me.soiField
        End Get
        Set
            Me.soiField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property road() As Object
        Get
            Return Me.roadField
        End Get
        Set
            Me.roadField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property moo() As Object
        Get
            Return Me.mooField
        End Get
        Set
            Me.mooField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property thmblnm() As Object
        Get
            Return Me.thmblnmField
        End Get
        Set
            Me.thmblnmField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property amphrnm() As Object
        Get
            Return Me.amphrnmField
        End Get
        Set
            Me.amphrnmField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property chngwtnm() As Object
        Get
            Return Me.chngwtnmField
        End Get
        Set
            Me.chngwtnmField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property tel() As Object
        Get
            Return Me.telField
        End Get
        Set
            Me.telField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property fax() As Object
        Get
            Return Me.faxField
        End Get
        Set
            Me.faxField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property amount() As Object
        Get
            Return Me.amountField
        End Get
        Set
            Me.amountField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class CLASS_NORYORMOR5Pharmacy

    Private nameField As Object

    Private lcnnoField As Object

    Private skillField As Object

    Private placeField As Object

    '''<remarks/>
    Public Property name() As Object
        Get
            Return Me.nameField
        End Get
        Set
            Me.nameField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property lcnno() As Object
        Get
            Return Me.lcnnoField
        End Get
        Set
            Me.lcnnoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property skill() As Object
        Get
            Return Me.skillField
        End Get
        Set
            Me.skillField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property place() As Object
        Get
            Return Me.placeField
        End Get
        Set
            Me.placeField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class CLASS_NORYORMOR5Storge

    Private nameField As Object

    Private lcnnoField As Object

    Private addrField As Object

    Private soiField As Object

    Private roadField As Object

    Private mooField As Object

    Private thmblnmField As Object

    Private amphrnmField As Object

    Private chngwtnmField As Object

    Private telField As Object

    Private faxField As Object

    '''<remarks/>
    Public Property name() As Object
        Get
            Return Me.nameField
        End Get
        Set
            Me.nameField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property lcnno() As Object
        Get
            Return Me.lcnnoField
        End Get
        Set
            Me.lcnnoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property addr() As Object
        Get
            Return Me.addrField
        End Get
        Set
            Me.addrField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property soi() As Object
        Get
            Return Me.soiField
        End Get
        Set
            Me.soiField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property road() As Object
        Get
            Return Me.roadField
        End Get
        Set
            Me.roadField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property moo() As Object
        Get
            Return Me.mooField
        End Get
        Set
            Me.mooField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property thmblnm() As Object
        Get
            Return Me.thmblnmField
        End Get
        Set
            Me.thmblnmField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property amphrnm() As Object
        Get
            Return Me.amphrnmField
        End Get
        Set
            Me.amphrnmField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property chngwtnm() As Object
        Get
            Return Me.chngwtnmField
        End Get
        Set
            Me.chngwtnmField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property tel() As Object
        Get
            Return Me.telField
        End Get
        Set
            Me.telField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property fax() As Object
        Get
            Return Me.faxField
        End Get
        Set
            Me.faxField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class CLASS_NORYORMOR5Drug

    Private nameField As Object

    Private styleField As Object

    Private amountField As Object

    Private packageField As Object

    Private mft_lotField As Object

    Private mft_dateField As Object

    Private exp_dateField As Object

    '''<remarks/>
    Public Property name() As Object
        Get
            Return Me.nameField
        End Get
        Set
            Me.nameField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property style() As Object
        Get
            Return Me.styleField
        End Get
        Set
            Me.styleField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property amount() As Object
        Get
            Return Me.amountField
        End Get
        Set
            Me.amountField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property package() As Object
        Get
            Return Me.packageField
        End Get
        Set
            Me.packageField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property mft_lot() As Object
        Get
            Return Me.mft_lotField
        End Get
        Set
            Me.mft_lotField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property mft_date() As Object
        Get
            Return Me.mft_dateField
        End Get
        Set
            Me.mft_dateField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property exp_date() As Object
        Get
            Return Me.exp_dateField
        End Get
        Set
            Me.exp_dateField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class CLASS_NORYORMOR5Mft

    Private nameField As Object

    Private addrField As Object

    Private soiField As Object

    Private roadField As Object

    Private mooField As Object

    Private thmblnmField As Object

    Private amphrnmField As Object

    Private chngwtnmField As Object

    Private countryField As Object

    '''<remarks/>
    Public Property name() As Object
        Get
            Return Me.nameField
        End Get
        Set
            Me.nameField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property addr() As Object
        Get
            Return Me.addrField
        End Get
        Set
            Me.addrField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property soi() As Object
        Get
            Return Me.soiField
        End Get
        Set
            Me.soiField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property road() As Object
        Get
            Return Me.roadField
        End Get
        Set
            Me.roadField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property moo() As Object
        Get
            Return Me.mooField
        End Get
        Set
            Me.mooField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property thmblnm() As Object
        Get
            Return Me.thmblnmField
        End Get
        Set
            Me.thmblnmField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property amphrnm() As Object
        Get
            Return Me.amphrnmField
        End Get
        Set
            Me.amphrnmField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property chngwtnm() As Object
        Get
            Return Me.chngwtnmField
        End Get
        Set
            Me.chngwtnmField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property country() As Object
        Get
            Return Me.countryField
        End Get
        Set
            Me.countryField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class CLASS_NORYORMOR5Medicine

    Private prefixField As Object

    Private nameField As Object

    Private lcnnoField As Object

    Private skillField As Object

    Private placeField As Object

    Private addrField As Object

    Private soiField As Object

    Private roadField As Object

    Private mooField As Object

    Private thmblnmField As Object

    Private amphrnmField As Object

    Private chngwtnmField As Object

    Private telField As Object

    Private faxField As Object

    '''<remarks/>
    Public Property prefix() As Object
        Get
            Return Me.prefixField
        End Get
        Set
            Me.prefixField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property name() As Object
        Get
            Return Me.nameField
        End Get
        Set
            Me.nameField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property lcnno() As Object
        Get
            Return Me.lcnnoField
        End Get
        Set
            Me.lcnnoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property skill() As Object
        Get
            Return Me.skillField
        End Get
        Set
            Me.skillField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property place() As Object
        Get
            Return Me.placeField
        End Get
        Set
            Me.placeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property addr() As Object
        Get
            Return Me.addrField
        End Get
        Set
            Me.addrField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property soi() As Object
        Get
            Return Me.soiField
        End Get
        Set
            Me.soiField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property road() As Object
        Get
            Return Me.roadField
        End Get
        Set
            Me.roadField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property moo() As Object
        Get
            Return Me.mooField
        End Get
        Set
            Me.mooField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property thmblnm() As Object
        Get
            Return Me.thmblnmField
        End Get
        Set
            Me.thmblnmField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property amphrnm() As Object
        Get
            Return Me.amphrnmField
        End Get
        Set
            Me.amphrnmField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property chngwtnm() As Object
        Get
            Return Me.chngwtnmField
        End Get
        Set
            Me.chngwtnmField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property tel() As Object
        Get
            Return Me.telField
        End Get
        Set
            Me.telField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property fax() As Object
        Get
            Return Me.faxField
        End Get
        Set
            Me.faxField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class CLASS_NORYORMOR5Antivirus

    Private nameField As Object

    Private substanceField As Object

    Private strengthField As Object

    Private mft_byField As Object

    Private countryField As Object

    Private import_byField As Object

    '''<remarks/>
    Public Property name() As Object
        Get
            Return Me.nameField
        End Get
        Set
            Me.nameField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property substance() As Object
        Get
            Return Me.substanceField
        End Get
        Set
            Me.substanceField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property strength() As Object
        Get
            Return Me.strengthField
        End Get
        Set
            Me.strengthField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property mft_by() As Object
        Get
            Return Me.mft_byField
        End Get
        Set
            Me.mft_byField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property country() As Object
        Get
            Return Me.countryField
        End Get
        Set
            Me.countryField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property import_by() As Object
        Get
            Return Me.import_byField
        End Get
        Set
            Me.import_byField = Value
        End Set
    End Property
End Class

