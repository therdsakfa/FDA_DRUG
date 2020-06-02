Namespace DAO_SP_PAYMENT


    Public MustInherit Class MAINCONTEXT       'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New LINQ_SP_PAYMENTDataContext   'ประกาศเพื่อใช้เป็น Class LINQ DataTable
        Public datas                            'ประกาศเ

    End Class
    Public Class TB_PAYMENT_DETAIL
        Inherits MAINCONTEXT                    'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New PAYMENT_DETAIL            'ใส่ชื่อ Table   (dh15rqt)
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.PAYMENT_DETAILs Where p.IDA = IDA Select p) 'การ Where   table(dh15rqts)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_REFNO(ByVal refno As String)

            datas = (From p In db.PAYMENT_DETAILs Where p.REF_NO = refno Select p) 'การ Where   table(dh15rqts)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function count_REFNO(ByVal refno As String) As Integer
            Dim i As Integer = 0
            datas = (From p In db.PAYMENT_DETAILs Where p.REF_NO = refno Select p) 'การ Where   table(dh15rqts)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Sub insert()
            db.PAYMENT_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.PAYMENT_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.PAYMENT_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_SYSTEMS_PAYMENT_DETAIL
        Inherits MAINCONTEXT                    'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New SYSTEMS_PAYMENT_DETAIL            'ใส่ชื่อ Table   (dh15rqt)
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.SYSTEMS_PAYMENT_DETAILs Where p.IDA = IDA Select p) 'การ Where   table(dh15rqts)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_REFNO(ByVal refno As String)

            datas = (From p In db.SYSTEMS_PAYMENT_DETAILs Where p.REF_NO = refno Select p) 'การ Where   table(dh15rqts)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function count_REFNO(ByVal refno As String) As Integer
            Dim i As Integer = 0
            datas = (From p In db.SYSTEMS_PAYMENT_DETAILs Where p.REF_NO = refno Select p) 'การ Where   table(dh15rqts)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Function count_REFNO_C_NO(ByVal refno As String, ByVal C_NO As String) As Integer
            Dim i As Integer = 0
            datas = (From p In db.SYSTEMS_PAYMENT_DETAILs Where p.REF_NO = refno And p.RCVNO = C_NO Select p) 'การ Where   table(dh15rqts)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Sub insert()
            db.SYSTEMS_PAYMENT_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.SYSTEMS_PAYMENT_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.SYSTEMS_PAYMENT_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
End Namespace
