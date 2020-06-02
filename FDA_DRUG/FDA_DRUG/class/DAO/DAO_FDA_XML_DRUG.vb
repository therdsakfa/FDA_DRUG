Namespace DAO_XML_DRUG_LCN

    Public MustInherit Class MAINCONTEXT2      'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New Linq_DAO_DRUGDataContext   'ประกาศเพื่อใช้เป็น Class LINQ DataTable


        Public datas                            'ประกาศเ

    End Class

    Public Class TB_XML_SEARCH_DRUG_LCN
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_SEARCH_DRUG_LCN

        Public Sub insert()
            db.XML_SEARCH_DRUG_LCNs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_SEARCH_DRUG_LCNs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_SEARCH_DRUG_LCNs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_identify(ByVal iden As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCNs Where p.CITIZEN_AUTHORIZE = iden Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_lcnsid(ByVal lcnsid As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCNs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.XML_SEARCH_DRUG_LCNs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1(ByVal u1 As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCNs Where p.Newcode_not = u1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

End Namespace