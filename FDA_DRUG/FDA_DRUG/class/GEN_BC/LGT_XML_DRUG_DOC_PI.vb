Public Class LGT_XML_DRUG_DOC_PI

    Private _XML_DRUG_PI As New XML_DRUG_PI
    Public Property XML_DRUG_PI() As XML_DRUG_PI
        Get
            Return _XML_DRUG_PI
        End Get
        Set(ByVal value As XML_DRUG_PI)
            _XML_DRUG_PI = value
        End Set
    End Property
    'Private _IDA As String
    'Public Property IDA() As String
    '    Get
    '        Return _IDA
    '    End Get
    '    Set(ByVal value As String)
    '        _IDA = value
    '    End Set
    'End Property
    'Private _pvncd As String
    'Public Property pvncd() As String
    '    Get
    '        Return _pvncd
    '    End Get
    '    Set(ByVal value As String)
    '        _pvncd = value
    '    End Set
    'End Property
    'Private _drgtpcd As String
    'Public Property drgtpcd() As String
    '    Get
    '        Return _drgtpcd
    '    End Get
    '    Set(ByVal value As String)
    '        _drgtpcd = value
    '    End Set
    'End Property
    'Private _rgttpcd As String
    'Public Property rgttpcd() As String
    '    Get
    '        Return _rgttpcd
    '    End Get
    '    Set(ByVal value As String)
    '        _rgttpcd = value
    '    End Set
    'End Property
    'Private _rgtno As String
    'Public Property rgtno() As String
    '    Get
    '        Return _rgtno
    '    End Get
    '    Set(ByVal value As String)
    '        _rgtno = value
    '    End Set
    'End Property
    'Private _PI_Th_Name_Medicinal_Product As String
    'Public Property PI_Th_Name_Medicinal_Product() As String
    '    Get
    '        Return _PI_Th_Name_Medicinal_Product
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Name_Medicinal_Product = value
    '    End Set
    'End Property
    'Private _PI_Th_Active_Ingradient_Strenght As String
    'Public Property PI_Th_Active_Ingradient_Strenght() As String
    '    Get
    '        Return _PI_Th_Active_Ingradient_Strenght
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Active_Ingradient_Strenght = value
    '    End Set
    'End Property
    'Private _PI_Th_Product_Desc As String
    'Public Property PI_Th_Product_Desc() As String
    '    Get
    '        Return _PI_Th_Product_Desc
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Product_Desc = value
    '    End Set
    'End Property
    'Private _PI_Th_Pharmacody_Pharmacoki As String
    'Public Property PI_Th_Pharmacody_Pharmacoki() As String
    '    Get
    '        Return _PI_Th_Pharmacody_Pharmacoki
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Pharmacody_Pharmacoki = value
    '    End Set
    'End Property
    'Private _PI_Th_Pharmdynamic As String
    'Public Property PI_Th_Pharmdynamic() As String
    '    Get
    '        Return _PI_Th_Pharmdynamic
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Pharmdynamic = value
    '    End Set
    'End Property
    'Private _PI_Th_Pharmacokinetic As String
    'Public Property PI_Th_Pharmacokinetic() As String
    '    Get
    '        Return _PI_Th_Pharmacokinetic
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Pharmacokinetic = value
    '    End Set
    'End Property
    'Private _PI_Th_Indication As String
    'Public Property PI_Th_Indication() As String
    '    Get
    '        Return _PI_Th_Indication
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Indication = value
    '    End Set
    'End Property
    'Private _PI_Th_Recommend_Dose As String
    'Public Property PI_Th_Recommend_Dose() As String
    '    Get
    '        Return _PI_Th_Recommend_Dose
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Recommend_Dose = value
    '    End Set
    'End Property
    'Private _PI_Th_Administration As String
    'Public Property PI_Th_Administration() As String
    '    Get
    '        Return _PI_Th_Administration
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Administration = value
    '    End Set
    'End Property
    'Private _PI_Th_Contraindication As String
    'Public Property PI_Th_Contraindication() As String
    '    Get
    '        Return _PI_Th_Contraindication
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Contraindication = value
    '    End Set
    'End Property
    'Private _PI_Th_Warning_Precaution As String
    'Public Property PI_Th_Warning_Precaution() As String
    '    Get
    '        Return _PI_Th_Warning_Precaution
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Warning_Precaution = value
    '    End Set
    'End Property
    'Private _PI_Th_Interaction As String
    'Public Property PI_Th_Interaction() As String
    '    Get
    '        Return _PI_Th_Interaction
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Interaction = value
    '    End Set
    'End Property
    'Private _PI_Th_Pregnancy_Lactation As String
    'Public Property PI_Th_Pregnancy_Lactation() As String
    '    Get
    '        Return _PI_Th_Pregnancy_Lactation
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Pregnancy_Lactation = value
    '    End Set
    'End Property
    'Private _PI_Th_Undesirable_Effect As String
    'Public Property PI_Th_Undesirable_Effect() As String
    '    Get
    '        Return _PI_Th_Undesirable_Effect
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Undesirable_Effect = value
    '    End Set
    'End Property
    'Private _PI_Th_Overdose As String
    'Public Property PI_Th_Overdose() As String
    '    Get
    '        Return _PI_Th_Overdose
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Overdose = value
    '    End Set
    'End Property
    'Private _PI_Th_Storage_Condition As String
    'Public Property PI_Th_Storage_Condition() As String
    '    Get
    '        Return _PI_Th_Storage_Condition
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Storage_Condition = value
    '    End Set
    'End Property
    'Private _PI_Th_Dose_From_Packaging As String
    'Public Property PI_Th_Dose_From_Packaging() As String
    '    Get
    '        Return _PI_Th_Dose_From_Packaging
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Dose_From_Packaging = value
    '    End Set
    'End Property
    'Private _PI_Th_MA_Holder As String
    'Public Property PI_Th_MA_Holder() As String
    '    Get
    '        Return _PI_Th_MA_Holder
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_MA_Holder = value
    '    End Set
    'End Property
    'Private _PI_Th_MA_Number As String
    'Public Property PI_Th_MA_Number() As String
    '    Get
    '        Return _PI_Th_MA_Number
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_MA_Number = value
    '    End Set
    'End Property
    'Private _PI_Th_Date_Approve As String
    'Public Property PI_Th_Date_Approve() As String
    '    Get
    '        Return _PI_Th_Date_Approve
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Date_Approve = value
    '    End Set
    'End Property
    'Private _PI_Th_Date_Revision As String
    'Public Property PI_Th_Date_Revision() As String
    '    Get
    '        Return _PI_Th_Date_Revision
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Th_Date_Revision = value
    '    End Set
    'End Property
    'Private _PI_Eng_Name_Medicinal_Product As String
    'Public Property PI_Eng_Name_Medicinal_Product() As String
    '    Get
    '        Return _PI_Eng_Name_Medicinal_Product
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Name_Medicinal_Product = value
    '    End Set
    'End Property
    'Private _PI_Eng_Active_Ingradient_Strenght As String
    'Public Property PI_Eng_Active_Ingradient_Strenght() As String
    '    Get
    '        Return _PI_Eng_Active_Ingradient_Strenght
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Active_Ingradient_Strenght = value
    '    End Set
    'End Property
    'Private _PI_Eng_Product_Desc As String
    'Public Property PI_Eng_Product_Desc() As String
    '    Get
    '        Return _PI_Eng_Product_Desc
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Product_Desc = value
    '    End Set
    'End Property
    'Private _PI_Eng_Pharmacody_Pharmacoki As String
    'Public Property PI_Eng_Pharmacody_Pharmacoki() As String
    '    Get
    '        Return _PI_Eng_Pharmacody_Pharmacoki
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Pharmacody_Pharmacoki = value
    '    End Set
    'End Property
    'Private _PI_Eng_Pharmdynamic As String
    'Public Property PI_Eng_Pharmdynamic() As String
    '    Get
    '        Return _PI_Eng_Pharmdynamic
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Pharmdynamic = value
    '    End Set
    'End Property
    'Private _PI_Eng_Pharmacokinetic As String
    'Public Property PI_Eng_Pharmacokinetic() As String
    '    Get
    '        Return _PI_Eng_Pharmacokinetic
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Pharmacokinetic = value
    '    End Set
    'End Property
    'Private _PI_Eng_Indication As String
    'Public Property PI_Eng_Indication() As String
    '    Get
    '        Return _PI_Eng_Indication
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Indication = value
    '    End Set
    'End Property
    'Private _PI_Eng_Recommend_Dose As String
    'Public Property PI_Eng_Recommend_Dose() As String
    '    Get
    '        Return _PI_Eng_Recommend_Dose
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Recommend_Dose = value
    '    End Set
    'End Property
    'Private _PI_Eng_Administration As String
    'Public Property PI_Eng_Administration() As String
    '    Get
    '        Return _PI_Eng_Administration
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Administration = value
    '    End Set
    'End Property
    'Private _PI_Eng_Contraindication As String
    'Public Property PI_Eng_Contraindication() As String
    '    Get
    '        Return _PI_Eng_Contraindication
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Contraindication = value
    '    End Set
    'End Property
    'Private _PI_Eng_Warning_Precaution As String
    'Public Property PI_Eng_Warning_Precaution() As String
    '    Get
    '        Return _PI_Eng_Warning_Precaution
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Warning_Precaution = value
    '    End Set
    'End Property
    'Private _PI_Eng_Interaction As String
    'Public Property PI_Eng_Interaction() As String
    '    Get
    '        Return _PI_Eng_Interaction
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Interaction = value
    '    End Set
    'End Property
    'Private _PI_Eng_Pregnancy_Lactation As String
    'Public Property PI_Eng_Pregnancy_Lactation() As String
    '    Get
    '        Return _PI_Eng_Pregnancy_Lactation
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Pregnancy_Lactation = value
    '    End Set
    'End Property
    'Private _PI_Eng_Undesirable_Effect As String
    'Public Property PI_Eng_Undesirable_Effect() As String
    '    Get
    '        Return _PI_Eng_Undesirable_Effect
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Undesirable_Effect = value
    '    End Set
    'End Property
    'Private _PI_Eng_Overdose As String
    'Public Property PI_Eng_Overdose() As String
    '    Get
    '        Return _PI_Eng_Overdose
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Overdose = value
    '    End Set
    'End Property
    'Private _PI_Eng_Storage_Condition As String
    'Public Property PI_Eng_Storage_Condition() As String
    '    Get
    '        Return _PI_Eng_Storage_Condition
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Storage_Condition = value
    '    End Set
    'End Property
    'Private _PI_Eng_Dose_From_Packaging As String
    'Public Property PI_Eng_Dose_From_Packaging() As String
    '    Get
    '        Return _PI_Eng_Dose_From_Packaging
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Dose_From_Packaging = value
    '    End Set
    'End Property
    'Private _PI_Eng_MA_Holder As String
    'Public Property PI_Eng_MA_Holder() As String
    '    Get
    '        Return _PI_Eng_MA_Holder
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_MA_Holder = value
    '    End Set
    'End Property
    'Private _PI_Eng_MA_Number As String
    'Public Property PI_Eng_MA_Number() As String
    '    Get
    '        Return _PI_Eng_MA_Number
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_MA_Number = value
    '    End Set
    'End Property
    'Private _PI_Eng_Date_Approve As String
    'Public Property PI_Eng_Date_Approve() As String
    '    Get
    '        Return _PI_Eng_Date_Approve
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Date_Approve = value
    '    End Set
    'End Property
    'Private _PI_Eng_Date_Revision As String
    'Public Property PI_Eng_Date_Revision() As String
    '    Get
    '        Return _PI_Eng_Date_Revision
    '    End Get
    '    Set(ByVal value As String)
    '        _PI_Eng_Date_Revision = value
    '    End Set
    'End Property
    'Private _Newcode As String
    'Public Property Newcode() As String
    '    Get
    '        Return _Newcode
    '    End Get
    '    Set(ByVal value As String)
    '        _Newcode = value
    '    End Set
    'End Property
End Class
