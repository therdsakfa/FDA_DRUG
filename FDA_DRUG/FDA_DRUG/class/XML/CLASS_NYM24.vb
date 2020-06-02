
'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class CLASS_NYM24

    Private drsampField As New CLASS_NYM24Drsamp

    Private dT_SHOWField As Object

    Private dT_MASTERField As Object

    Private rcvnoField As Object

    Private rcvdateField As Object

    Private staffField As Object

    Private wRITE_ATField As Object

    Private wRITE_DATEField As Object

    Private iMPORT_AMOUNTSField As Object

    Private drug_containField As Object

    Private contain_detailField As Object

    Private give_toField As Object

    Private pAKAGEField() As CLASS_NYM24PAKAGE


    '''<remarks/>
    Public Property drsamp() As CLASS_NYM24Drsamp
        Get
            Return Me.drsampField
        End Get
        Set
            Me.drsampField = Value
        End Set
    End Property
    '''<remarks/>
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
    '''<remarks/>
    Public Property rcvno() As Object
        Get
            Return Me.rcvnoField
        End Get
        Set
            Me.rcvnoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property rcvdate() As Object
        Get
            Return Me.rcvdateField
        End Get
        Set
            Me.rcvdateField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property staff() As Object
        Get
            Return Me.staffField
        End Get
        Set
            Me.staffField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property WRITE_AT() As Object
        Get
            Return Me.wRITE_ATField
        End Get
        Set
            Me.wRITE_ATField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property WRITE_DATE() As Object
        Get
            Return Me.wRITE_DATEField
        End Get
        Set
            Me.wRITE_DATEField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IMPORT_AMOUNTS() As Object
        Get
            Return Me.iMPORT_AMOUNTSField
        End Get
        Set
            Me.iMPORT_AMOUNTSField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property drug_contain() As Object
        Get
            Return Me.drug_containField
        End Get
        Set
            Me.drug_containField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property contain_detail() As Object
        Get
            Return Me.contain_detailField
        End Get
        Set
            Me.contain_detailField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property give_to() As Object
        Get
            Return Me.give_toField
        End Get
        Set
            Me.give_toField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("PAKAGE", IsNullable:=False)>
Public Property PAKAGE() As CLASS_NYM24PAKAGE()
    Get
        Return Me.pAKAGEField
    End Get
    Set
        Me.pAKAGEField = Value
    End Set
End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class CLASS_NYM24Drsamp

    Private pREFIXField As Object

    Private nAMEField As Object

    Private iN_NAMEField As Object

    Private iN_NAME_DETAILField As Object

    Private iN_NAME_DETAIL1Field As Object

    Private iN_NAME_DETAIL2Field As Object

    Private iN_NAME_DETAIL3Field As Object

    Private iN_NAME_DETAIL4Field As Object

    Private iN_NAME_DETAIL5Field As Object

    Private iN_NAME_DETAIL6Field As Object

    Private lCNNO_SHOWSField As Object

    Private cHK_PERMISSION_REQUESTField As Object

    Private addrField As Object

    Private soiField As Object

    Private roadField As Object

    Private mooField As Object

    Private thmblnmField As Object

    Private amphrnmField As Object

    Private chngwtnmField As Object

    Private telField As Object

    Private rANKField As Object

    Private dRUG_THAINAMEField As Object

    Private dRUG_ENGNAMEField As Object

    '''<remarks/>
    Public Property PREFIX() As Object
        Get
            Return Me.pREFIXField
        End Get
        Set
            Me.pREFIXField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NAME() As Object
        Get
            Return Me.nAMEField
        End Get
        Set
            Me.nAMEField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IN_NAME() As Object
        Get
            Return Me.iN_NAMEField
        End Get
        Set
            Me.iN_NAMEField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IN_NAME_DETAIL() As Object
        Get
            Return Me.iN_NAME_DETAILField
        End Get
        Set
            Me.iN_NAME_DETAILField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IN_NAME_DETAIL1() As Object
        Get
            Return Me.iN_NAME_DETAIL1Field
        End Get
        Set
            Me.iN_NAME_DETAIL1Field = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IN_NAME_DETAIL2() As Object
        Get
            Return Me.iN_NAME_DETAIL2Field
        End Get
        Set
            Me.iN_NAME_DETAIL2Field = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IN_NAME_DETAIL3() As Object
        Get
            Return Me.iN_NAME_DETAIL3Field
        End Get
        Set
            Me.iN_NAME_DETAIL3Field = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IN_NAME_DETAIL4() As Object
        Get
            Return Me.iN_NAME_DETAIL4Field
        End Get
        Set
            Me.iN_NAME_DETAIL4Field = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IN_NAME_DETAIL5() As Object
        Get
            Return Me.iN_NAME_DETAIL5Field
        End Get
        Set
            Me.iN_NAME_DETAIL5Field = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IN_NAME_DETAIL6() As Object
        Get
            Return Me.iN_NAME_DETAIL6Field
        End Get
        Set
            Me.iN_NAME_DETAIL6Field = Value
        End Set
    End Property

    '''<remarks/>
    Public Property LCNNO_SHOWS() As Object
        Get
            Return Me.lCNNO_SHOWSField
        End Get
        Set
            Me.lCNNO_SHOWSField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CHK_PERMISSION_REQUEST() As Object
        Get
            Return Me.cHK_PERMISSION_REQUESTField
        End Get
        Set
            Me.cHK_PERMISSION_REQUESTField = Value
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
    Public Property RANK() As Object
        Get
            Return Me.rANKField
        End Get
        Set
            Me.rANKField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DRUG_THAINAME() As Object
        Get
            Return Me.dRUG_THAINAMEField
        End Get
        Set
            Me.dRUG_THAINAMEField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DRUG_ENGNAME() As Object
        Get
            Return Me.dRUG_ENGNAMEField
        End Get
        Set
            Me.dRUG_ENGNAMEField = Value
        End Set
    End Property
End Class

<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class CLASS_NYM24PAKAGE

    Private contain_detailField As Object

    '''<remarks/>
    Public Property contain_detail() As Object
        Get
            Return Me.contain_detailField
        End Get
        Set
            Me.contain_detailField = Value
        End Set
    End Property
End Class
