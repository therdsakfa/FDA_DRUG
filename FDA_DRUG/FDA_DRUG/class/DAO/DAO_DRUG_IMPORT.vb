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
        Public Sub getdata_dl(ByVal DL As String)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_2s Where p.DL = DL Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_2s Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_2s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_2s Where p.NYM2_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA_STATUS(ByVal IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_2s Where p.NYM2_IDA = IDA And p.STATUS_ID Is Nothing Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_2s Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA_and_PROCESS_ID(ByVal DL As String)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_2s Where p.DL = DL And p.STATUS_ID = 8 Select p)     'อย่าลืมเช็คตรงนี้
            For Each Me.fields In datas
            Next
        End Sub

        Friend Sub GetDataby_IDA()
            Throw New NotImplementedException()
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
        Public Sub getdata_dl(ByVal DL As String)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_3s Where p.DL = DL Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_3s Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_3s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_3s Where p.NYM3_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA_STATUS(ByVal IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_3s Where p.NYM3_IDA = IDA And p.STATUS_ID Is Nothing Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_3s Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA_and_PROCESS_ID(ByVal DL As String)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_3s Where p.DL = DL And p.STATUS_ID = 8 Select p)     'อย่าลืมเช็คตรงนี้
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
        Public Sub getdata_dl(ByVal DL As String)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_4s Where p.DL = DL Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_4s Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_4s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_4s Where p.NYM4_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA_STATUS(ByVal IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_4s Where p.NYM4_IDA = IDA And p.STATUS_ID Is Nothing Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_4s Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA_and_PROCESS_ID(ByVal DL As String)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_4s Where p.DL = DL And p.STATUS_ID = 8 Select p)     'อย่าลืมเช็คตรงนี้
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
        Public Sub getdata_dl(ByVal DL As String)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_5s Where p.DL = DL Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_5s Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_5s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_5s Where p.NYM5_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA_STATUS(ByVal IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_5s Where p.NYM5_IDA = IDA And p.STATUS_ID Is Nothing Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_5s Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA_and_PROCESS_ID(ByVal DL As String)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_5s Where p.DL = DL And p.STATUS_ID = 8 Select p)     'อย่าลืมเช็คตรงนี้
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
        Public Sub getdata_dl(ByVal DL As String)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_6s Where p.DL = DL Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_6s Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_6s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_6s Where p.NYM6_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA_STATUS(ByVal IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_6s Where p.NYM6_IDA = IDA And p.STATUS_ID Is Nothing Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_NYM_6s Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA_and_PROCESS_ID(ByVal DL As String)
            datas = (From p In db.FDA_DRUG_IMPORT_NYM_6s Where p.DL = DL And p.STATUS_ID = 8 Select p)     'อย่าลืมเช็คตรงนี้
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class All_file_attrach
        Inherits MAINCONTEXT
        Public fields As New M_ATTACH_DOC

        Public Sub insert()
            db.M_ATTACH_DOCs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.M_ATTACH_DOCs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        'ขาด DL 
        Public Sub getfile_type_dl(ByVal nym As Integer, ByVal dl As Integer)
            '    datas = (From p In db.M_ATTACH_DOCs Where p.ATTACH_TYPE = nym And p.DL = dl Select p)
            '    For Each Me.fields In datas

            '    Next
        End Sub
    End Class
    Public Class ClsDBTRANSACTION_UPLOAD
        Inherits MAINCONTEXT

        Public fields As New FDA_DRUG_IMPORT_UPLOAD


        Public Sub insert()
            db.FDA_DRUG_IMPORT_UPLOADs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.FDA_DRUG_IMPORT_UPLOADs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.FDA_DRUG_IMPORT_UPLOADs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.FDA_DRUG_IMPORT_UPLOADs Where p.FK_DRUG_IMPORT = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class




End Class
