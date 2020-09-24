Public Class DAO_DRUG_IMPORT
    Public MustInherit Class MAINCONTEXT        'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New LINQ_FDA_DRUG_IMPORTDataContext   'ประกาศเพื่อใช้เป็น Class LINQ DataTable


        Public datas                            'ประกาศเ

    End Class

    Public Class TB_FDA_DRUG_IMPORT_NYM_1
        Inherits MAINCONTEXT
        Public fields As New FDA_DRUG_IMPORT_NYM_1

        Public Sub insert()
            db.FDA_DRUG_IMPORT_NYM_1s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.FDA_DRUG_IMPORT_NYM_1s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub


        Public Sub getdata_ida(ByVal ida As Integer)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_1s Where p.NYM1_IDA = ida Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_FDA_DRUG_IMPORT_NYM_2
        Inherits MAINCONTEXT
        Public fields As New FDA_DRUG_IMPORT_NYM_2

        Public Sub insert()
            db.FDA_DRUG_IMPORT_NYM_2s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.FDA_DRUG_IMPORT_NYM_2s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub getdata_ida(ByVal ida As Integer)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_2s Where p.NYM2_IDA = ida Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_2s Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class TB_FDA_DRUG_IMPORT_NYM_3
        Inherits MAINCONTEXT
        Public fields As New FDA_DRUG_IMPORT_NYM_3

        Public Sub insert()
            db.FDA_DRUG_IMPORT_NYM_3s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.FDA_DRUG_IMPORT_NYM_3s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub


        Public Sub getdata_ida(ByVal ida As Integer)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_3s Where p.NYM3_IDA = ida Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_FDA_DRUG_IMPORT_NYM_4
        Inherits MAINCONTEXT
        Public fields As New FDA_DRUG_IMPORT_NYM_4

        Public Sub insert()
            db.FDA_DRUG_IMPORT_NYM_4s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.FDA_DRUG_IMPORT_NYM_4s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub


        Public Sub getdata_ida(ByVal ida As Integer)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_4s Where p.NYM4_IDA = ida Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class TB_FDA_DRUG_IMPORT_NYM_5
        Inherits MAINCONTEXT
        Public fields As New FDA_DRUG_IMPORT_NYM_5

        Public Sub insert()
            db.FDA_DRUG_IMPORT_NYM_5s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.FDA_DRUG_IMPORT_NYM_5s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub


        Public Sub getdata_ida(ByVal ida As Integer)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_5s Where p.NYM5_IDA = ida Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_FDA_DRUG_IMPORT_NYM_6
        Inherits MAINCONTEXT
        Public fields As New FDA_DRUG_IMPORT_NYM_6

        Public Sub insert()
            db.FDA_DRUG_IMPORT_NYM_6s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.FDA_DRUG_IMPORT_NYM_6s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub getdata_ida(ByVal ida As Integer)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_6s Where p.NYM6_IDA = ida Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class

End Class
